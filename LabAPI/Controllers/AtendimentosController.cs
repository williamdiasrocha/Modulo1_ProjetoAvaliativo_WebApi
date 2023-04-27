using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabApi.DTOS;
using LabApi.Enums;
using LabApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtendimentosController : ControllerBase
    {
        private readonly LabApiContext _context;
        public AtendimentosController(LabApiContext context)
        {
            _context = context;
        }
        [HttpPut("AtendimentoMedico")]
        public ActionResult Put(int pacienteId, int medicoId, string Observacoes)
        {
            // Procurar pelo paciente pelo Id
        var pacienteModel = _context.Pacientes.FirstOrDefault(p => p.IdPessoa == pacienteId);
        if (pacienteModel == null)
        {
            return StatusCode(400, $"Paciente com código {pacienteId} não encontrado");
        }

        // Procurar pelo médico pelo Id
        var medicoModel = _context.Medicos.FirstOrDefault(m => m.IdPessoa == medicoId);
        if (medicoModel == null)
        {
            return StatusCode (400, $"Médico com código {medicoId} não encontrado");
        }

        // Incrementar os atributos do atendimento
        pacienteModel.TotalAtendimentos++;
        medicoModel.TotalAtendimentos++;

        // Alterar o status do paciente para "Atendido"
        pacienteModel.statusAtendimento = StatusAtendimento.Atendido;

        // Salvar as alterações no banco de dados
        _context.SaveChanges();

        // Criar o objeto AtendimentoModel
        var atendimentoModel = new AtendimentoModel
        {
            IdPaciente = pacienteModel.IdPessoa,
            IdMedico = medicoModel.IdPessoa,
            DataAtendimento = DateTime.Now,
            Observacoes = Observacoes
        };

        // Adicionar o objeto AtendimentoModel ao contexto do banco de dados
        _context.Atendimentos.Add(atendimentoModel);
        _context.SaveChanges(); // Salvar as alterações no banco de dados

        // Retornar o atendimento atualizado
        var atendimentoDTO = new AtendimentoDTO
        {
            Observacoes = "Atendimento Realizado com Sucesso!",
            IdAtendimento = atendimentoModel.IdAtendimento, // Inclui o idAtendimento gerado após a inserção na tabela AtendimentoModel
            PacienteId = pacienteModel.IdPessoa,
            NomePaciente = pacienteModel.NomeCompleto,
            MedicoId = medicoModel.IdPessoa,
            NomeMedico = medicoModel.NomeCompleto,
            StatusAtendimento = pacienteModel.statusAtendimento.ToString(),
            DataAtendimento = atendimentoModel.DataAtendimento // Usa a data do atendimento da tabela AtendimentoModel
        };

        return Ok(atendimentoDTO);
        }
    }
}
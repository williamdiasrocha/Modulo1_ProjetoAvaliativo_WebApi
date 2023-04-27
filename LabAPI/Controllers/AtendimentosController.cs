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
    [Route("api/[controller]")]
    public class AtendimentosController : ControllerBase
    {
        private readonly LabApiContext _context;
        public AtendimentosController(LabApiContext context)
        {
            _context = context;
        }
        [HttpPut]
        public ActionResult Put(int pacienteId, int medicoId)
        {
            // Procurar pelo paciente pelo Id
            var pacienteModel = _context.Pacientes.FirstOrDefault(p => p.IdPessoa == pacienteId);
            if (pacienteModel == null)
            {
                return NotFound($"Paciente com código {pacienteId} não encontrado");
            }

            // Procurar pelo médico pelo Id
            var medicoModel = _context.Medicos.FirstOrDefault(m => m.IdPessoa == medicoId);
            if (medicoModel == null)
            {
                return NotFound($"Médico com código {medicoId} não encontrado");
            }

            // Incrementar os atributos do atendimento
            pacienteModel.TotalAtendimentos++;
            medicoModel.TotalAtendimentos++;

            // Alterar o status do paciente para "Atendido"
            pacienteModel.statusAtendimento = StatusAtendimento.Atendido;

            // Salvar as alterações no banco de dados
            _context.SaveChanges();

            // Retornar o atendimento atualizado
            var atendimentoDTO = new AtendimentoDTO
            {
                PacienteId = pacienteModel.IdPessoa,
                NomePaciente = pacienteModel.NomeCompleto,
                MedicoId = medicoModel.IdPessoa,
                NomeMedico = medicoModel.NomeCompleto,
                StatusAtendimento = pacienteModel.statusAtendimento.ToString(),
                DataAtendimento = DateTime.Now
            };

            return Ok(atendimentoDTO);
        }
    }
}
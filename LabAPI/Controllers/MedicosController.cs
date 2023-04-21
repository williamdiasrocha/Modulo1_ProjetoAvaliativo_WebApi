using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LabAPI.DTO;
using LabAPI.Models;
using Microsoft.AspNetCore.Mvc;
using static LabAPI.DTO.MedicoDTO.Especializacao_Clinica;
using static LabAPI.Models.Medico;

namespace LabAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicosController : ControllerBase
    {
        private readonly LabApiContext _context;
        public MedicosController(LabApiContext context)
        {
            _context = context;
        }

         [HttpPost]
        [Route("medicos")]
        public ActionResult Inserir([FromBody] MedicoDTO medicoDTO)
        {
            if (medicoDTO == null) 
            {
                return StatusCode(400, "Médico não informado.");
            }

            if (string.IsNullOrWhiteSpace(medicoDTO.NomeCompleto)) 
            {
                return StatusCode(400, "Nome completo não inserido. Favor preencher com dados válidos.");
            }

            if (Regex.IsMatch(medicoDTO.NomeCompleto, @"\d")) 
            {
                return StatusCode(400, "O nome completo deve conter apenas letras.");
            }

            if (medicoDTO.DataNascimento == null || medicoDTO.DataNascimento == DateTime.MinValue) 
            {
                return StatusCode(400, "Data de nascimento não informada.");
            }

            if (string.IsNullOrWhiteSpace(medicoDTO.CPF)) 
            {
                return StatusCode(400, "CPF não inserido. Favor preencher com dados válidos.");
            }

            if (!Regex.IsMatch(medicoDTO.CPF, @"^\d{11}$")) 
            {
                return StatusCode(400, "CPF deve conter apenas números e ter 11 dígitos.");
            }

            if (_context.Medicos.Any(x => x.CPF == medicoDTO.CPF)) 
            {
                return StatusCode(409, "CPF já cadastrado.");
            }

            if (string.IsNullOrEmpty(medicoDTO.CRM_UF)) 
            {
                return StatusCode(400, "CRM_UF é um item obrigatório.");
            }

            
                var especializacoes = new List<EspecializacaoClinica>();
                foreach (var item in medicoDTO.EspecializacaoClinica)
                {
                    especializacoes.Add((EspecializacaoClinica)item);
                }

                

                // Insere o paciente no banco de dados
                var medico = new Medico()
                {  
                    
                    NomeCompleto = medicoDTO.NomeCompleto,
                    DataNascimento = medicoDTO.DataNascimento.Value,
                    CPF = medicoDTO.CPF,          
                    CRM_UF = medicoDTO.CRM_UF,
                    Genero = medicoDTO.Genero,
                    Telefone = medicoDTO.Telefone,
                    Especializacao_Clinica = especializacoes.FirstOrDefault(),
                    InstituicaoEnsinoFormacao = string.Join("|", medicoDTO.InstituicaoEnsinoFormacao),               
                    TotalAtendimentos = medicoDTO.TotalAtendimentos
                };
            try
            {
                _context.Medicos.Add(medico);
                _context.SaveChanges();

                var response = new
                {
                    mensagem = "Paciente inserido com sucesso!",
                    Identificador = medico.Id,
                    Atendimentos = new List<Medico>(),
                    Nome = medico.NomeCompleto,
                    Genero = medico.Genero,
                    DataNascimento = medico.DataNascimento,
                    CPF = medico.CPF,
                    Telefone = medico.Telefone,
                    CRM_UF = medico.CRM_UF,
                    Especializacao_Clinica = medico.Especializacao_Clinica,
                    InstituicaoEnsinoFormacao = medico.InstituicaoEnsinoFormacao,
                    
                };

                return StatusCode( 201, response);
            }
            catch
            {
                return StatusCode(409, "Erro ao inserir Paciente.");
            }
        }
    }
}
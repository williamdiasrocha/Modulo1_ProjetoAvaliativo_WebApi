using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabAPI.Context;
using LabAPI.DTO;
using LabAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabAPI.Controllers
{
    [ApiController]
    [Route("Api")]
    public class PacientesController : ControllerBase
    {
        private readonly LabApiContext _context;
        public PacientesController(LabApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("pacientes")]
        public ActionResult Inserir([FromBody] PacienteDTO pacienteDTO)
        {
                // Verifica se os campos obrigatórios foram preenchidos
            if(string.IsNullOrWhiteSpace(pacienteDTO.NomeCompleto) || string.IsNullOrWhiteSpace(pacienteDTO.CPF) || pacienteDTO.DataNascimento == null)
            {
                return BadRequest("Dados não inseridos. Favor preencher com dados válidos.");
            }
                // Verifica se o CPF já existe no Banco de Dados
            if(_context.Pacientes.Any(x => x.CPF == pacienteDTO.CPF))
            {
                return Conflict("CPF já existe.");
            }
            if (string.IsNullOrEmpty(pacienteDTO.ContatoEmergencia)) 
            {
                return BadRequest("Contato de Emergência é item obrigatório.");
            }

            // Insere o paciente no banco de dados
            var paciente = new Paciente()
            {  
                NomeCompleto = pacienteDTO.NomeCompleto,
                DataNascimento = pacienteDTO.DataNascimento,
                CPF = pacienteDTO.CPF,          
                ContatoEmergencia = pacienteDTO.ContatoEmergencia,
                Genero = pacienteDTO.Genero,
                Telefone = pacienteDTO.Telefone,
                _Alergias = pacienteDTO._Alergias, 
                _CuidadosEspecificos = pacienteDTO._CuidadosEspecificos,               
                Convenio = pacienteDTO.Convenio
            };
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();

            return Ok("Paciente inserido com sucesso!");
        }
    }
}
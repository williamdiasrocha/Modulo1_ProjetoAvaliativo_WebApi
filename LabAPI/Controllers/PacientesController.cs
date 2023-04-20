using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabAPI.Models;
using LabAPI.DTO;
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
            if (pacienteDTO == null)  // verifica se paciente é nulo
            {
                return StatusCode(400, "Paciente não informado.");
            }
            if (Regex.IsMatch(pacienteDTO.NomeCompleto, @"\d")) // verifica se a string NomeCompleto possui algum número
            {
                return StatusCode(400, "O Nome Completo deve conter apenas letras.");
            }
            // Verifica se os campos obrigatórios foram preenchidos
            if(string.IsNullOrWhiteSpace(pacienteDTO.NomeCompleto))
            {
                return StatusCode(400, "Nome completo não inseridos. Favor preencher com dados válidos.");
            }
            
            if( pacienteDTO.DataNascimento == null || pacienteDTO.DataNascimento == DateTime.MinValue )
            {
                return StatusCode(400, "Data de Nascimento não informado.");
            }

            if( string.IsNullOrWhiteSpace(pacienteDTO.CPF))
            {
                return StatusCode(400, "CPF com erro.");
            }
            if(pacienteDTO.CPF.Length != 11)
            {
                return StatusCode(400, "CPF deve conter exatamente 11 números.");
            }
            // Verifica se o CPF já existe no Banco de Dados
            if(_context.Pacientes.Any(x => x.CPF == pacienteDTO.CPF))
            {
                return StatusCode(409, "CPF já existe.");
            }          
            if(!Regex.IsMatch(pacienteDTO.CPF, @"^\d+S"))
            {
                return StatusCode(400, "CPF deve conter apenas números.");
            }
                
            
                
            if (string.IsNullOrEmpty(pacienteDTO.ContatoEmergencia)) 
            {
                return StatusCode(400, "Contato de Emergência é item obrigatório.");
            }
            try
            {
                // Insere o paciente no banco de dados
                var paciente = new Paciente()
                {  
                    NomeCompleto = pacienteDTO.NomeCompleto,
                    DataNascimento = pacienteDTO.DataNascimento.Value,
                    CPF = pacienteDTO.CPF,          
                    ContatoEmergencia = pacienteDTO.ContatoEmergencia,
                    Genero = pacienteDTO.Genero,
                    Telefone = pacienteDTO.Telefone,
                    Alergias =  string.Join("|",pacienteDTO.Alergias),
                    CuidadosEspecificos = string.Join("|", pacienteDTO.CuidadosEspecificos),               
                    Convenio = pacienteDTO.Convenio
                };
                _context.Pacientes.Add(paciente);
                _context.SaveChanges();

                var response = new
                {
                    mensagem = "Paciente inserido com sucesso!",
                    Identificador = paciente.Id,
                    Atendimentos = new List<Paciente>(),
                    Nome = paciente.NomeCompleto,
                    Genero = paciente.Genero,
                    DataNascimento = paciente.DataNascimento,
                    CPF = paciente.CPF,
                    Telefone = paciente.Telefone,
                    ContatoEmergencia = paciente.ContatoEmergencia,
                    Alergias = paciente.Alergias,
                    CuidadosEspecificos = paciente.CuidadosEspecificos,
                    Convenio = paciente.Convenio
                };

                return StatusCode( 201, response);
            }
            catch
            {
                return StatusCode(409, "Erro ao inserir Paciente.");
            }
        }

        [HttpPut]
        [Route("pacientes/{id}")]
        public ActionResult Atualizar(int id, [FromBody] PacienteDTO pacienteDTO)
        {
            // Verificação se o paciente com o ID está inserido dentro do banco de dados pacientes.
            var pacienteExistente = _context.Pacientes.FirstOrDefault(x => x.Id == id);
            if (pacienteExistente ==  null)
            {
                return StatusCode(404, "PACIENTE não encontrado na base de dados.");
            }

            // Atualizar as informações novas do pacientes
            pacienteExistente.NomeCompleto = pacienteDTO.NomeCompleto;
            pacienteExistente.Genero = pacienteDTO.Genero;
            pacienteExistente.DataNascimento = pacienteDTO.DataNascimento.HasValue ? pacienteDTO.DataNascimento.Value : pacienteExistente.DataNascimento;
            pacienteExistente.CPF = pacienteDTO.CPF;
            pacienteExistente.Telefone = pacienteDTO.Telefone;
            pacienteExistente.ContatoEmergencia = pacienteDTO.ContatoEmergencia;
            pacienteExistente.Alergias = string.Join(" | ", pacienteDTO.Alergias);
            pacienteExistente.CuidadosEspecificos = string.Join(" | ", pacienteDTO.CuidadosEspecificos);
            pacienteExistente.Convenio = pacienteDTO.Convenio;

            try
            {
                // Salva as alterações na base de dados
                _context.SaveChanges();

                var response = new
                {
                    mensagem = "Paciente Atualizado com sucesso.",
                    Identificador = pacienteExistente.Id,
                    Atendimentos = new List<Paciente>(),
                    Nome = pacienteExistente.NomeCompleto,
                    Genero = pacienteExistente.Genero,
                    DataNascimento = pacienteExistente.DataNascimento,
                    CPF = pacienteExistente.CPF,
                    Telefone = pacienteExistente.Telefone,
                    ContatoEmergencia = pacienteExistente.ContatoEmergencia,
                    Alergias = pacienteExistente.Alergias,
                    CuidadosEspecificos = pacienteExistente.CuidadosEspecificos,
                    Convenio = pacienteExistente.Convenio
                };

                return StatusCode( 201, response);
            }
            catch
            {
                return StatusCode(409, "Erro ao Atualizar Paciente.");
            }
        }

        [HttpPut]
        [Route("pacientes/{identificador}/status")]
        public ActionResult AtualizarStatusAtendimento(string identificador, [FromBody] StatusAtendimentoDTO statusAtendimentoDTO)
       {
            if (!int.TryParse(identificador, out var pacienteId))
            {
                return StatusCode(404, "Identificador Invalido.");
            }

            var paciente = _context.Pacientes.FirstOrDefault(x => x.Id == pacienteId);
            if (paciente == null)
            {
                return StatusCode(404, "Paciente não encontrado.");
            }

            string statusStr = statusAtendimentoDTO.statusAtendimento.ToString();
            if(string.IsNullOrWhiteSpace(statusStr) || !Enum.TryParse(statusStr, out Paciente.StatusAtendimento statusAtendimento))
            {
                return StatusCode(400, "Status Inválido");
            }

            
            paciente.statusAtendimento = (Paciente.StatusAtendimento)statusAtendimento;
            _context.SaveChanges();
            return Ok(paciente);
        }


        [HttpGet]
        [Route("pacientes")]
        public ActionResult Obter([FromQuery] string statusAtendimento)
        {
            var pacientes = _context.Pacientes.AsQueryable();

            if(!string.IsNullOrEmpty(statusAtendimento))
            {
                switch (statusAtendimento.ToUpper())
                {
                    case "AGUARDANDO_ATENDIMENTO":
                        pacientes = pacientes.Where(p => p.statusAtendimento == Paciente.StatusAtendimento.AguardandoAtendimento);
                        break;
                    case "EM_ATENDIMENTO":
                        pacientes = pacientes.Where(p => p.statusAtendimento == Paciente.StatusAtendimento.EmAtendimento);
                        break;
                    case "ATENDIDO":
                        pacientes = pacientes.Where(p => p.statusAtendimento == Paciente.StatusAtendimento.Atendido);
                        break;
                    case "NÂO_ATENDIDO":
                        pacientes = pacientes.Where(p => p.statusAtendimento == Paciente.StatusAtendimento.NaoAtendido);
                        break;
                    default:
                        return BadRequest("O Valor informado não é valido");

                }
            }

            var resultado = pacientes.ToList().Select(p => new
            {
                Identificador = p.Id,
                Nome = p.NomeCompleto,
                Genero = p.Genero,
                DataNascimento = p.DataNascimento,
                CPF = p.CPF,
                Telefone = p.Telefone,
                ContatoEmergencia = p.ContatoEmergencia,
                Alergias = p.Alergias,
                CuidadosEspecificos = p.CuidadosEspecificos,
                Convenio = p.Convenio,
                Status = p.statusAtendimento.ToString()
            });

            return Ok(resultado);
        }

        
    }
}
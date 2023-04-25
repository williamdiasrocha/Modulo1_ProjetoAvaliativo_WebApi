using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LabApi.DTOS;
using LabApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly LabApiContext _context;
        public PacientesController(LabApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Pacientes")]
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
                var paciente = new PacienteModel()
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
                    Identificador = paciente.IdPessoa,
                    Atendimentos = new List<PacienteModel>(),
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
            var pacienteExistente = _context.Pacientes.FirstOrDefault(x => x.IdPessoa == id);
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
                    Identificador = pacienteExistente.IdPessoa,
                    Atendimentos = new List<PacienteModel>(),
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

        [HttpPut("/api/Pacientes/{identificador}/status")]
        public ActionResult AtualizarStatusAtendimento(int identificador, [FromBody] AtualizacaoStatusDTO atualizacaoStatusDTO)
        {
            // Verifica se o paciente existe na base de dados
            var paciente = _context.Pacientes.FirstOrDefault(x => x.IdPessoa == identificador);
            if (paciente == null)
            {
                return NotFound("Paciente não encontrado.");
            }

            // Verifica se o campo status foi informado e se é válido
            if (string.IsNullOrEmpty(atualizacaoStatusDTO.NovoStatus) || !Enum.TryParse<PacienteModel.StatusAtendimento>(atualizacaoStatusDTO.NovoStatus, out var novoStatus))
            {
                return BadRequest("Status inválido.");
            }

            // Atualiza o status do paciente
            paciente.statusAtendimento = novoStatus;
            _context.SaveChanges();

            // Retorna os dados atualizados do paciente
            return Ok(new StatusAtendimentoDTO
            {
                Id = paciente.IdPessoa,
                NomeCompleto = paciente.NomeCompleto,
                Status = paciente.statusAtendimento.ToString(),
                OpcoesDisponiveis = EnumHelper.GetDisplayNames<PacienteModel.StatusAtendimento>()
            });
        }
    


        [HttpGet]
        [Route("pacientes")]
        public ActionResult Obter([FromQuery] string statusAtendimento = "", int? identificador = null)
        {
             var pacientes = _context.Pacientes.AsQueryable();

            if(identificador.HasValue)
            {
                pacientes = pacientes.Where(p => p.IdPessoa == identificador.Value);
            }
            else if(!string.IsNullOrEmpty(statusAtendimento))
            {
                switch (statusAtendimento.ToUpper())
                {
                    case "AGUARDANDO_ATENDIMENTO":
                        pacientes = pacientes.Where(p => p.statusAtendimento == PacienteModel.StatusAtendimento.AguardandoAtendimento);
                        break;
                    case "EM_ATENDIMENTO":
                        pacientes = pacientes.Where(p => p.statusAtendimento == PacienteModel.StatusAtendimento.EmAtendimento);
                        break;
                    case "ATENDIDO":
                        pacientes = pacientes.Where(p => p.statusAtendimento == PacienteModel.StatusAtendimento.Atendido);
                        break;
                    case "NÂO_ATENDIDO":
                        pacientes = pacientes.Where(p => p.statusAtendimento == PacienteModel.StatusAtendimento.NaoAtendido);
                        break;
                    default:
                        return BadRequest("O Valor informado não é valido");

                }
            }

            var resultado = pacientes.ToList().Select(p => new
            {
                Identificador = p.IdPessoa,
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

        [HttpGet]
        [Route("pacientes/{id})")]
        public ActionResult ObterPorId(int id)
        {
              // BUSCAR O PACIENTE PELO ID INFORMADO
              var paciente = _context.Pacientes.FirstOrDefault(p => p.IdPessoa == id);

              // Verifica se o Paciente foi encontrado na base de dados
              if (paciente == null)
              {
                return StatusCode(404, "Paciente não encontrado.");
              }

              // cria o objeto de resposta
              var resposta = new
              {
                Identificador = paciente.IdPessoa,
                Nome = paciente.NomeCompleto,
                Genero = paciente.Genero,
                DataNascimento = paciente.DataNascimento,
                CPF = paciente.CPF,
                Telefone = paciente.Telefone,
                ContatoEmergencia = paciente.ContatoEmergencia,
                Alergias = paciente.Alergias?.Split(" | "),
                CuidadosEspecificos = paciente.CuidadosEspecificos?.Split(" | "),
                Convenio = paciente.Convenio
              };

              // Retorna o paciente encontrado na base de dados
              return Ok(resposta);
        }

        [HttpDelete]
        [Route("pacientes/{id}")]
        public ActionResult Delete(int id)
        {
            // Fazer a busca do paciente a ser excluido na base de dados pelo Id
            var paciente = _context.Pacientes.FirstOrDefault(p => p.IdPessoa == id);
            if (paciente == null)
            {
                return StatusCode(404, "Paciente não encontrado na base de dados");
            }

            try
            {
                // Remove o paciente na base de dados pelo ID
                _context.Pacientes.Remove(paciente);
                _context.SaveChanges();

                // Retorna uma resposta de sucesso sem o corpo
                return StatusCode(204, "Paciente Removido com Sucesso.");
            }
            catch
            {
                return StatusCode(500, "Erro ao excluir os registros do Paciente.");
            }
        }
        
    
    }
}
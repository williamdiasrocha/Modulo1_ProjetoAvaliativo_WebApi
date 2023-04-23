using System.Text.RegularExpressions;
using LabAPI.DTO;
using LabAPI.Models;
using Microsoft.AspNetCore.Mvc;
using static LabAPI.Models.Medico;
using static LabAPI.DTO.MedicoDTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

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

            List<EspecializacaoClinica> especializacoes = new List<EspecializacaoClinica>();
                foreach (var item in medicoDTO.EspecializacaoClinica)
            {
                var especializacao = (EspecializacaoClinica)Enum.Parse(typeof(EspecializacaoClinica), item);
                especializacoes.Add(especializacao);
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
                    Especializacao_Clinica = medico.Especializacao_Clinica.ToString(),
                    InstituicaoEnsinoFormacao = medico.InstituicaoEnsinoFormacao,
                    
                };

                return StatusCode( 201, response);
            }
            catch
            {
                return StatusCode(409, "Erro ao inserir Paciente.");
            }
        }

        [HttpPut("{identificador}")]
        public ActionResult AtualizarMedico(int id, [FromBody] MedicoDTO medicoDTO)
        {
            var medico = _context.Medicos.FirstOrDefault(m => m.Id == id);
            if (medico == null)
            {
                return StatusCode(404, "Médico não encontrado");
            }
            if (medicoDTO == null)
            {
                return StatusCode(400, "Dados do médico não informados.");
            }
            if(string.IsNullOrWhiteSpace(medicoDTO.NomeCompleto))
            {
                return StatusCode(400, "Nome completo não inserido. Favor preencher com dados válidos.");
            }
            if (Regex.IsMatch(medicoDTO.NomeCompleto, @"\d"))
            {
                return StatusCode (400, "O nome completo deve conter apenas letras.");
            }
            if(medicoDTO.DataNascimento == null || medicoDTO.DataNascimento == DateTime.MinValue)
            {
                return StatusCode(400, "Data de Nascimento não informada.");
            }
            if (string.IsNullOrWhiteSpace(medicoDTO.CPF))
            {
                return StatusCode(400, "CPF não informado. Favor preencher com dados válidos");
            }
            if(!Regex.IsMatch(medicoDTO.CPF, @"^\d{11}$"))
            {
                return StatusCode(400, "CPF deve conter apenas números e ter 11 dígitos");
            }
            if(_context.Medicos.Any(m => m.CPF == medicoDTO.CPF && m.Id != id))
            {
                return StatusCode(409, "CPF já cadastrado na base de dados.");
            }
            if(string.IsNullOrWhiteSpace(medicoDTO.CRM_UF))
            {
                return StatusCode(400, "CRM_UF é um item obrigatório.");
            }

            var especializacoes = new List<EspecializacaoClinica>();
            foreach (var item in medicoDTO.EspecializacaoClinica)
            {
                if (Enum.TryParse(item.ToString(), out EspecializacaoClinica especializacao))
                {
                    especializacoes.Add(especializacao);
                }
            }

            medico.NomeCompleto = medicoDTO.NomeCompleto;
            medico.DataNascimento = medicoDTO.DataNascimento.Value;
            medico.CPF = medicoDTO.CPF;
            medico.CRM_UF = medicoDTO.CRM_UF;
            medico.Genero = medicoDTO.Genero;
            medico.Telefone = medicoDTO.Telefone;
            medico.Especializacao_Clinica = especializacoes.FirstOrDefault();
            medico.InstituicaoEnsinoFormacao = string.Join (" | ", medicoDTO.InstituicaoEnsinoFormacao);
            medico.TotalAtendimentos = medicoDTO.TotalAtendimentos;

            try
            {
                _context.SaveChanges();

                var resposta = new
                {
                    mensagem = "Médico atualizado com sucesso.",
                    Identificador = medico.Id,
                    Nome = medico.NomeCompleto,
                    Genero = medico.Genero,
                    DataNascimento = medico.DataNascimento,
                    CPF = medico.CPF,
                    Telefone = medico.Telefone,
                    CRM_UF = medico.CRM_UF,
                    EspecializacaoClinica = medico.Especializacao_Clinica.ToString(),
                    InstituicaoEnsinoFormacao = medico.InstituicaoEnsinoFormacao,
                    TotalAtendimentos = medico.TotalAtendimentos
                };

                return StatusCode(200, resposta);
            }
            catch
            {
                return StatusCode(409, "Erro ao atualizar o cadastro do médico.");
            }
        }

        [HttpPut("/api/Medicos/{identificador}/status")]
        public ActionResult AtualizarStatusMedico(int identificador, [FromBody] AtualizacaoStatusMedicoDTO atualizacaoStatusMedicoDTO)
        {
            // Verifica se o Medico existe na base de dados
            var medico = _context.Medicos.FirstOrDefault(x => x.Id == identificador);
            if (medico == null)
            {
                return StatusCode(404, "Medico não encontrado.");
            }

            // Verifica se o campo status foi informado e se é válido
            if (string.IsNullOrEmpty(atualizacaoStatusMedicoDTO.NovoStatusM) || !Enum.TryParse<Medico.EstadoSistema>(atualizacaoStatusMedicoDTO.NovoStatusM, out var novoStatus))
            {
                return StatusCode(400, "Status inválido.");
            }

            // Atualiza o status do Medico
            medico.Estado_No_Sistema = novoStatus;
            _context.SaveChanges();

            // Retorna os dados atualizados do Medico
            return Ok(new StatusAtendimentoMedicoDTO
            {
                 
                Id = medico.Id,
                NomeCompleto = medico.NomeCompleto,
                Status = medico.Estado_No_Sistema.ToString(),
                StatusDisponiveis = EnumHelperMedico.GetDisplayNames<Medico.EstadoSistema>()
            });
        }

        [HttpGet]
        [Route("Medicos")]
        public ActionResult Obter([FromQuery] string status = "", int? identificador = null)
        {
            var medicos = _context.Medicos.AsQueryable();

            if(identificador.HasValue)
            {
                medicos = medicos.Where(p => p.Id == identificador.Value);
            }
            else if(!string.IsNullOrEmpty(status))
            {
                switch (status.ToUpper())
                {
                    case "ATIVO":
                        medicos = medicos.Where(p => p.Estado_No_Sistema == Medico.EstadoSistema.Ativo);
                        break;
                    case "INATIVO":
                        medicos = medicos.Where(p => p.Estado_No_Sistema == Medico.EstadoSistema.Inativo);
                        break;
                    default:
                        return BadRequest("O Valor informado não é valido pra status");

                }
            }

            var resultado = medicos.ToList().Select(p => new
            {
                Identificador = p.Id,
                Nome = p.NomeCompleto,
                Genero = p.Genero,
                DataNascimento = p.DataNascimento,
                CPF = p.CPF,
                Telefone = p.Telefone,
                CRM_UF = p.CRM_UF,
                Especializacao_Clinica = p.Especializacao_Clinica,
                InstituicaoEnsinoFormacao = p.InstituicaoEnsinoFormacao,
                Status = p.Estado_No_Sistema.ToString()
            });

            
            return Ok(resultado);
        }

        [HttpGet]
        [Route("Medicos/{id})")]
        public ActionResult ObterMedicoPorId(int id)
        {
              // BUSCAR O medico PELO ID INFORMADO
              var medico = _context.Medicos.FirstOrDefault(p => p.Id == id);

              // Verifica se o medico foi encontrado na base de dados
              if (medico == null)
              {
                return StatusCode(404, "Medico não encontrado.");
              }

              // cria o objeto de resposta
              var resposta = new
              {
                Identificador = medico.Id,
                Nome = medico.NomeCompleto,
                Genero = medico.Genero,
                DataNascimento = medico.DataNascimento,
                CPF = medico.CPF,
                Telefone = medico.Telefone,
                CRM_UF = medico.CRM_UF,
                InstituicaoEnsinoFormacao = medico.InstituicaoEnsinoFormacao,
                Especializacao_Clinica = medico.Especializacao_Clinica,
                Status = medico.Estado_No_Sistema
              };

              // Retorna o medico encontrado na base de dados
              return Ok(resposta);
        }

        [HttpDelete]
        [Route("Medicos/{id}")]
        public ActionResult Delete(int id)
        {
            // Fazer a busca do medico a ser excluido na base de dados pelo Id
            var medico = _context.Medicos.FirstOrDefault(p => p.Id == id);
            if (medico == null)
            {
                return StatusCode(404, "Medico não encontrado na base de dados");
            }

            try
            {
                // Remove o medico na base de dados pelo ID
                _context.Medicos.Remove(medico);
                _context.SaveChanges();

                // Retorna uma resposta de sucesso sem o corpo
                return StatusCode(204, "Médico Removido com Sucesso.");
            }
            catch
            {
                return StatusCode(500, "Erro ao excluir os registros do Médico.");
            }
        }
    }
}
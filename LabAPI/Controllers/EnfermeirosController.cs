using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LabAPI.DTO;
using LabAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnfermeirosController : ControllerBase
    {
        private readonly LabApiContext _context;
        public EnfermeirosController(LabApiContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("medicos")]
        public ActionResult Inserir([FromBody] EnfermeiroDTO enfermeiroDTO)
        {
            if (enfermeiroDTO == null) 
            {
                return StatusCode(400, "Enfermeiro não informado.");
            }

            if (string.IsNullOrWhiteSpace(enfermeiroDTO.NomeCompleto)) 
            {
                return StatusCode(400, "Nome completo não inserido. Favor preencher com dados válidos.");
            }

            if (Regex.IsMatch(enfermeiroDTO.NomeCompleto, @"\d")) 
            {
                return StatusCode(400, "O nome completo deve conter apenas letras.");
            }

            if (enfermeiroDTO.DataNascimento == null || enfermeiroDTO.DataNascimento == DateTime.MinValue) 
            {
                return StatusCode(400, "Data de nascimento não informada.");
            }

            if (string.IsNullOrWhiteSpace(enfermeiroDTO.CPF)) 
            {
                return StatusCode(400, "CPF não inserido. Favor preencher com dados válidos.");
            }

            if (!Regex.IsMatch(enfermeiroDTO.CPF, @"^\d{11}$")) 
            {
                return StatusCode(400, "CPF deve conter apenas números e ter 11 dígitos.");
            }

            if (_context.Medicos.Any(x => x.CPF == enfermeiroDTO.CPF)) 
            {
                return StatusCode(409, "CPF já cadastrado.");
            }

            if (string.IsNullOrEmpty(enfermeiroDTO.COFEN_UF)) 
            {
                return StatusCode(400, "COFEN_UF é um item obrigatório.");
            }

                // Insere o Enfermeiro no banco de dados
                var enfermeiro = new Enfermeiro()
                {  
                    
                    NomeCompleto = enfermeiroDTO.NomeCompleto,
                    DataNascimento = enfermeiroDTO.DataNascimento.Value,
                    CPF = enfermeiroDTO.CPF,          
                    COFEN_UF = enfermeiroDTO.COFEN_UF,
                    Genero = enfermeiroDTO.Genero,
                    Telefone = enfermeiroDTO.Telefone,
                    InstituicaoEnsinoFormacao = string.Join("|", enfermeiroDTO.InstituicaoEnsinoFormacao),               
                    
                };
            try
            {
                _context.Enfermeiros.Add(enfermeiro);
                _context.SaveChanges();

                var resposta = new
                {
                    mensagem = "Enfermeiro inserido com sucesso!",
                    Identificador = enfermeiroDTO.Id,
                    Atendimentos = new List<Enfermeiro>(),
                    Nome = enfermeiroDTO.NomeCompleto,
                    Genero = enfermeiroDTO.Genero,
                    DataNascimento = enfermeiroDTO.DataNascimento,
                    CPF = enfermeiroDTO.CPF,
                    Telefone = enfermeiroDTO.Telefone,
                    COFEN_UF = enfermeiroDTO.COFEN_UF,
                    InstituicaoEnsinoFormacao = enfermeiroDTO.InstituicaoEnsinoFormacao,
                    
                };

                return StatusCode( 201, resposta);
            }
            catch
            {
                return StatusCode(409, "Erro ao inserir Enfermeiro.");
            }
        }

        [HttpPut("{identificador}")]
        public ActionResult AtualizarEnfermeiro(int id, [FromBody] EnfermeiroDTO enfermeiroDTO)
        {
            var enfermeiro = _context.Enfermeiros.FirstOrDefault(m => m.Id == id);
            if (enfermeiro == null)
            {
                return StatusCode(404, "Enfermeiro não encontrado");
            }
            if (enfermeiroDTO == null)
            {
                return StatusCode(400, "Dados do enfermeiro não informados.");
            }
            if(string.IsNullOrWhiteSpace(enfermeiroDTO.NomeCompleto))
            {
                return StatusCode(400, "Nome completo não inserido. Favor preencher com dados válidos.");
            }
            if (Regex.IsMatch(enfermeiroDTO.NomeCompleto, @"\d"))
            {
                return StatusCode (400, "O nome completo deve conter apenas letras.");
            }
            if(enfermeiroDTO.DataNascimento == null || enfermeiroDTO.DataNascimento == DateTime.MinValue)
            {
                return StatusCode(400, "Data de Nascimento não informada.");
            }
            if (string.IsNullOrWhiteSpace(enfermeiroDTO.CPF))
            {
                return StatusCode(400, "CPF não informado. Favor preencher com dados válidos");
            }
            if(!Regex.IsMatch(enfermeiroDTO.CPF, @"^\d{11}$"))
            {
                return StatusCode(400, "CPF deve conter apenas números e ter 11 dígitos");
            }
            if(_context.Medicos.Any(m => m.CPF == enfermeiroDTO.CPF && m.Id != id))
            {
                return StatusCode(409, "CPF já cadastrado na base de dados.");
            }
            if(string.IsNullOrWhiteSpace(enfermeiroDTO.COFEN_UF))
            {
                return StatusCode(400, "COFEN_UF é um item obrigatório.");
            }

           

            enfermeiro.NomeCompleto = enfermeiroDTO.NomeCompleto;
            enfermeiro.DataNascimento = enfermeiroDTO.DataNascimento.Value;
            enfermeiro.CPF = enfermeiroDTO.CPF;
            enfermeiro.COFEN_UF = enfermeiroDTO.COFEN_UF;
            enfermeiro.Genero = enfermeiroDTO.Genero;
            enfermeiro.Telefone = enfermeiroDTO.Telefone;
            enfermeiro.InstituicaoEnsinoFormacao = string.Join (" | ", enfermeiroDTO.InstituicaoEnsinoFormacao);
            

            try
            {
                _context.SaveChanges();

                var resposta = new
                {
                    mensagem = "Médico atualizado com sucesso.",
                    Identificador = enfermeiro.Id,
                    Nome = enfermeiro.NomeCompleto,
                    Genero = enfermeiro.Genero,
                    DataNascimento = enfermeiro.DataNascimento,
                    CPF = enfermeiro.CPF,
                    Telefone = enfermeiro.Telefone,
                    CRM_UF = enfermeiro.COFEN_UF,
                    InstituicaoEnsinoFormacao = enfermeiro.InstituicaoEnsinoFormacao
                    
                };

                return StatusCode(200, resposta);
            }
            catch
            {
                return StatusCode(409, "Erro ao atualizar o cadastro do Enfermeiro.");
            }
        }

        [HttpGet]
        public ActionResult<List<EnfermeiroDTO>> Get()
        {
            var enfermeiros = _context.Enfermeiros.Select(e => new EnfermeiroDTO
            {
                Id = e.Id,
                NomeCompleto = e.NomeCompleto,
                Genero = e.Genero,
                DataNascimento = e.DataNascimento,
                CPF = e.CPF,
                COFEN_UF = e.COFEN_UF,
                Telefone = e.Telefone,
                InstituicaoEnsinoFormacao = e.InstituicaoEnsinoFormacao
            }).ToList();

            return enfermeiros;
        }

        [HttpGet("{id}")]
        public ActionResult<EnfermeiroDTO> Get(int id)
        {
            var enfermeiroDTO = new EnfermeiroDTO();
            var enfermeiro = _context.Enfermeiros.FirstOrDefault(e => e.Id == id);
            if(enfermeiro == null)
            {
                return StatusCode(404, "Enfermeiro não encontrado na base de dados,");
            }

            enfermeiroDTO.Id = enfermeiro.Id;
            enfermeiroDTO.NomeCompleto = enfermeiro.NomeCompleto;
            enfermeiroDTO.Genero = enfermeiro.Genero;
            enfermeiroDTO.DataNascimento = enfermeiro.DataNascimento;
            enfermeiroDTO.CPF = enfermeiro.CPF;
            enfermeiroDTO.COFEN_UF = enfermeiro.COFEN_UF;
            enfermeiroDTO.Telefone = enfermeiro.Telefone;
            enfermeiroDTO.InstituicaoEnsinoFormacao = enfermeiro.InstituicaoEnsinoFormacao;

            return Ok(enfermeiroDTO);
        }
        [HttpDelete]
        [Route("Enfermeiros/{id}")]
        public ActionResult DeleteEnfermeiro(int id)
        {
            // Fazer a busca do enfermeiro a ser excluido na base de dados pelo Id
            var enfermeiro = _context.Enfermeiros.FirstOrDefault(p => p.Id == id);
            if (enfermeiro == null)
            {
                return StatusCode(404, "Enfermeiro não encontrado na base de dados");
            }

            try
            {
                // Remove o Enfermeiro na base de dados pelo ID
                _context.Enfermeiros.Remove(enfermeiro);
                _context.SaveChanges();

                // Retorna uma resposta de sucesso sem o corpo
                return StatusCode(204, "Enfermeiro Removido com Sucesso.");
            }
            catch
            {
                return StatusCode(500, "Erro ao excluir os registros do Enfermeiro.");
            }
        }
    }
}
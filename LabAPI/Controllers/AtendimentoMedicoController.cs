using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabAPI.DTO;
using LabAPI.IServices;
using LabAPI.Models;
using Microsoft.AspNetCore.Mvc;
using static LabAPI.DTO.MedicoDTO;
using LabAPI.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace LabAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtendimentoMedicoController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly LabApiContext _context;
        private readonly IMedicoRepository _medicoRepository;
        private readonly IMapper _mapper;
        private readonly IAtendimentoRepository _atendimentoRepository;



        public AtendimentoMedicoController(LabApiContext context, IPacienteRepository pacienteRepository, IMapper mapper, IMedicoRepository medicoRepository, IAtendimentoRepository atendimentoRepository)
        {
            _context = context;
            _pacienteRepository = pacienteRepository;
            _medicoRepository = medicoRepository;
            _mapper = mapper;
            _atendimentoRepository = atendimentoRepository;

            // Configuração do mapeamento de Medico para MedicoDTO
            _mapper = new MapperConfiguration(cfg => {
            cfg.CreateMap<Medico, MedicoDTO>();
            }).CreateMapper();
        }

        [HttpPut("/api/atendimentos")]
        
        public IActionResult RealizarAtendimento ([FromBody] AtendimentoDTO atendimentoDTO)
        {
            if (atendimentoDTO == null)
            {
                return BadRequest("Dados inválidos");
            }

            if (atendimentoDTO.Medico.Id == null || atendimentoDTO.Paciente.Id == null)
            {
                return BadRequest("Código do paciente e do médico são obrigatórios");
            }

            var medico = _medicoRepository.GetMedico(atendimentoDTO.Medico.Id.Value);
            if (medico == null)
            {
                return NotFound("Médico não encontrado");
            }
            

            var paciente = _pacienteRepository.ObterPorId(atendimentoDTO.Paciente.Id.Value);
            if (paciente == null)
            {
                return NotFound("Paciente não encontrado");
            }
            var medicoDTO = _mapper.Map<MedicoDTO>(medico);
            var pacienteDTO = _mapper.Map<PacienteDTO>(paciente);

            // Incrementa atributos de atendimento do paciente e médico envolvidos
            medico.TotalAtendimentos++;
            paciente.TotalAtendimentos++;
            var novoAtendimento = new Atendimento 
            {
                Paciente = pacienteDTO,
                Medico = medicoDTO,
                DataAtendimento = DateTime.Now
            };
            paciente.Atendimentos.Add(novoAtendimento);

            _medicoRepository.UpdateMedico(medico);
            _pacienteRepository.Atualizar(paciente);

            try
            {
                _medicoRepository.Save();
                _pacienteRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_pacienteRepository.PacienteExists(atendimentoDTO.PacienteId))
                {
                    return NotFound("Paciente não encontrado");
                }
                else if (!_medicoRepository.MedicoExists(atendimentoDTO.MedicoId))
                {
                    return NotFound("Médico não encontrado");
                }
                else
                {
                    throw;
                }
            }

            var atendimento = new Atendimento
            {
                Medico = _mapper.Map<MedicoDTO>(medico),
                Paciente = _mapper.Map<PacienteDTO>(paciente),
                DataAtendimento = DateTime.Now
            };

            _atendimentoRepository.AddAtendimento(atendimento);
            _atendimentoRepository.Save();

            var responseDTO = new AtendimentoDTO
            {
                Paciente = _mapper.Map<PacienteDTO>(paciente),
                Medico = _mapper.Map<MedicoDTO>(medico),
                DataAtendimento = atendimento.DataAtendimento
            };

            return Ok(responseDTO);
        }
                    
    }
}
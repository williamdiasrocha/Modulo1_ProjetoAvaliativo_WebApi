using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabAPI.IServices;
using LabAPI.Models;
using LabAPI.DTO;
using Microsoft.EntityFrameworkCore;

namespace LabAPI.Services
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly LabApiContext _context;

        public AtendimentoRepository(LabApiContext context)
        {
            _context = context;
        }

        public void AddAtendimento(AtendimentoDTO atendimentoDTO)
        {
            _context.Atendimentos.Add(atendimentoDTO);
        }

        public void AddAtendimento(Atendimento atendimento)
        {
            throw new NotImplementedException();
        }

        public bool AtendimentoExists(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Atendimento> GetAllAtendimentos()
        {
            throw new NotImplementedException();
        }

        public Atendimento GetAtendimentoById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Atendimento> GetAtendimentos()
        {
             var atendimentos = _context.Atendimentos
            .Include(a => a.Paciente)
            .Include(a => a.Medico)
            .ToList();

        return atendimentos.Select(a => new Atendimento
        {
            Id = a.Id,
            Paciente = a.Paciente,
            Medico = a.Medico,
            DataAtendimento = a.DataAtendimento,
            Atendimentos = new List<Atendimento>()
        });;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateAtendimento(Atendimento atendimento)
        {
            throw new NotImplementedException();
        }
    }
}
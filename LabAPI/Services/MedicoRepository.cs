using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabAPI.IServices;
using LabAPI.Models;

namespace LabAPI.Services
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly LabApiContext _context;

        public MedicoRepository(LabApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Medico> GetMedicos()
        {
            return _context.Medicos.ToList();
        }

        public Medico GetMedico(int medicoId)
        {
            return _context.Medicos.FirstOrDefault(m => m.Id == medicoId);
        }

        public void AddMedico(Medico medico)
        {
            _context.Medicos.Add(medico);
        }

        public void UpdateMedico(Medico medico)
        {
            _context.Medicos.Update(medico);
        }

        public void DeleteMedico(Medico medico)
        {
            _context.Medicos.Remove(medico);
        }

        public bool MedicoExists(int medicoId)
        {
            return _context.Medicos.Any(m => m.Id == medicoId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
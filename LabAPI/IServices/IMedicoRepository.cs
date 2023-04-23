using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabAPI.Models;

namespace LabAPI.IServices
{
    public interface IMedicoRepository
    {
        IEnumerable<Medico> GetMedicos();
        Medico GetMedico(int medicoId);
        void AddMedico(Medico medico);
        void UpdateMedico(Medico medico);
        void DeleteMedico(Medico medico);
        bool MedicoExists(int medicoId);
        

        void Save();
    }
}
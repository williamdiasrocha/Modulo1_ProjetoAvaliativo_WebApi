using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabAPI.Models;

namespace LabAPI.IServices
{
    public interface IAtendimentoRepository
    {
        void AddAtendimento(Atendimento atendimento);
        IEnumerable<Atendimento> GetAllAtendimentos();
        Atendimento GetAtendimentoById(int id);
        void UpdateAtendimento(Atendimento atendimento);
        bool AtendimentoExists(int id);
        void Save();
        }
}
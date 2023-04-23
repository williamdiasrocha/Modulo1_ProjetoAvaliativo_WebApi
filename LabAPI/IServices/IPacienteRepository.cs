using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabAPI.Models;
using LabAPI.Services;

namespace LabAPI.IServices
{
    public interface IPacienteRepository 
    {
        void Adicionar(Paciente paciente);
        void Atualizar(Paciente paciente);
        void Remover(int id);
        Paciente ObterPorId(int id);
        bool PacienteExists(int id);
        void Save();
    }
}
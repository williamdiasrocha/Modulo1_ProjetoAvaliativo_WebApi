using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabAPI.IServices;
using LabAPI.Models;

namespace LabAPI.Services
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly List<Paciente> _pacientes = new List<Paciente>();

        public void Adicionar(Paciente paciente)
        {
            _pacientes.Add(paciente);
        }

        public void Atualizar(Paciente paciente)
        {
            var pacienteExistente = _pacientes.FirstOrDefault(p => p.Id == paciente.Id);
            if(pacienteExistente != null)
            {
                pacienteExistente.NomeCompleto = paciente.NomeCompleto;
                pacienteExistente.Genero = paciente.Genero;
                pacienteExistente.DataNascimento = paciente.DataNascimento;
                pacienteExistente.Telefone = paciente.Telefone;
                pacienteExistente.Alergias = paciente.Alergias;
                pacienteExistente.ContatoEmergencia = paciente.ContatoEmergencia;
                pacienteExistente.CuidadosEspecificos = paciente.CuidadosEspecificos;
                pacienteExistente.Convenio = paciente.Convenio;
            }
        }

        public void Remover(int id)
        {
            var paciente = _pacientes.FirstOrDefault(p => p.Id == id);
            if(paciente != null)
            {
                _pacientes.Remove(paciente);
            }
        }

        public Paciente ObterPorId(int id)
        {
            return _pacientes.FirstOrDefault(p => p.Id == id);
        }

        public void Atualizar(IEnumerable<Paciente> pacienteModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Paciente> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public bool PacienteExists(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
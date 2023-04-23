using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabAPI.DTO;

namespace LabAPI.Models
{
    public class Atendimento
    {
        public int Id { get; set; }
        public PacienteDTO Paciente { get; set; }
        public MedicoDTO Medico { get; set; }
        public DateTime DataAtendimento { get; set; }
        public List<Atendimento> Atendimentos { get; set; }
    }
}
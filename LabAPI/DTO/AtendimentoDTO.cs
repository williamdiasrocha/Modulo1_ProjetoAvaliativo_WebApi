using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabAPI.DTO
{
    public class AtendimentoDTO
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public PacienteDTO Paciente { get; set; }
        public int MedicoId { get; set; }
        public MedicoDTO Medico { get; set; }
        public DateTime DataAtendimento { get; set; }
    }
}
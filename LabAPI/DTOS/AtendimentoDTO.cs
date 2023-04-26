using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabApi.DTOS
{
    public class AtendimentoDTO
    {
        
        public int PacienteId { get; set; }
        
        public int MedicoId { get; set; }
   
        public string NomePaciente { get; set; }
        public DateTime DataAtendimento { get; set; }
        public string NomeMedico { get; set; }
        public string StatusAtendimento { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LabAPI.Models.Paciente;

namespace LabAPI.DTO
{
    public class PacienteDTO
    {
        public string NomeCompleto { get; set; }
        public string Genero { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }  
        public string ContatoEmergencia { get; set; }
        public List<string> Alergias { get; set; } = new List<string>();
        public List<string> CuidadosEspecificos { get; set; } = new List<string>();
        public string Convenio { get; set; }

        


          
        
    }
}
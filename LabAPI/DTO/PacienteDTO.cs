using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LabAPI.Models;
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
        

         public enum StatusAtendimento
        {
            [Display(Name = "Aguardando Atendimento")]
            AguardandoAtendimento = 1,
            [Display(Name = "Em Atendimento")]
            EmAtendimento = 2,
            [Display(Name = "Atendido")]
            Atendido = 3,
            [Display(Name = "Não Atendido")]
            NaoAtendido = 4,
            [Display(Name = "Cancelado")]
            Cancelado = 5
        }
         

          
        
    }
}
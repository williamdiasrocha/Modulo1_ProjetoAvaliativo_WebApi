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
        public int? Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Genero { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }  
        public string ContatoEmergencia { get; set; }
        public List<string> Alergias { get; set; } = new List<string>();
        public List<string> CuidadosEspecificos { get; set; } = new List<string>();
        public string Convenio { get; set; }
        public int TotalAtendimento { get; set; } = 0;
        public string StatusAtendimentoNovo { get; set; }
        public List<StatusAtendimento> Atendimentos { get; set; }
        public List<Atendimento> Atendimento { get; set; }
        

         public enum StatusAtendimento
        {
            [Display(Name = "Aguardando Atendimento = 1")]
            AguardandoAtendimento = 1,
            [Display(Name = "Em Atendimento = 2")]
            EmAtendimento = 2,
            [Display(Name = "Atendido = 3")]
            Atendido = 3,
            [Display(Name = "Não Atendido = 4")]
            NaoAtendido = 4,
            [Display(Name = "Cancelado = 5")]
            Cancelado = 5
        }

        public PacienteDTO()
        {

        }
        public PacienteDTO(Paciente paciente)
        {
            Id = paciente.Id;
            NomeCompleto = paciente.NomeCompleto;
        }
         

          
        
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using LabAPI.DTO;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace LabAPI.Models
{
    [Table("PACIENTES")]
    public class Paciente : Pessoa
    {   
        [Column("CONTATO_EMERGENCIA"), Required] public string ContatoEmergencia { get; set; }
        [Column("ALERGIAS")] public string Alergias { get; set; } 
        [Column("CUIDADOS_ESPECIAIS")] public string CuidadosEspecificos { get; set; } 
        [Column("CONVENIO"), MaxLength(30)] public string Convenio { get; set; }
        [Column("STATUS_ATENDIMENTO")][JsonConverter(typeof(StringEnumConverter))] public StatusAtendimento statusAtendimento { get; set; }
        [Column("TOTAL_ATENDIMENTOS")] public int TotalAtendimentos { get; set; } = 0;
        [Column ("ATENDIMENTO")] public List<Atendimento> Atendimentos { get; set; }
      


        public Paciente()
        {
            ContatoEmergencia = "N/A";
        }

        // Método para retornar as opções do enum
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
        }

        
    }
}
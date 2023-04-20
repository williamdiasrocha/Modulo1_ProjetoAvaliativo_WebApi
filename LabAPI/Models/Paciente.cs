using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static LabAPI.DTO.StatusAtendimentoDTO;

namespace LabAPI.Models
{
    [Table("PACIENTES")]
    public class Paciente : Pessoa
    {   
        [Column("CONTATO_EMERGENCIA"), Required] public string ContatoEmergencia { get; set; }
        [Column("ALERGIAS")] public string Alergias { get; set; } 
        [Column("CUIDADOS_ESPECIAIS")] public string CuidadosEspecificos { get; set; } 
        [Column("CONVENIO"), MaxLength(30)] public string Convenio { get; set; }
        [Column("STATUS_ATENDIMENTO")] public StatusAtendimento statusAtendimento { get; set; }
        [Column("TOTAL_ATENDIMENTOS")] public int TotalAtendimentos { get; set; } = 0;
      


        public Paciente()
        {
            ContatoEmergencia = "N/A";
        }
        
        public enum StatusAtendimento
        {
            AguardandoAtendimento = 1,
            EmAtendimento = 2,
            Atendido = 3,
            NaoAtendido = 4,
        }
    }
}
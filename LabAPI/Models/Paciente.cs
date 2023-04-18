using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabAPI.Models
{
    [Table("PACIENTES")]
    public class Paciente : Pessoa
    {
        [Column("CONTATO_EMERGENCIA"), Required] public string ContatoEmergencia { get; set; }
        [Column("ALERGIAS")] public List<string> _Alergias { get; set; } = new List<string>();
        [Column("CUIDADOS_ESPECIAIS")] public List<string> _CuidadosEspecificos { get; set; } = new List<string>();
        [Column("CONVENIO"), MaxLength(30)] public string Convenio { get; set; }
        [Column("STATUS_ATENDIMENTO")] public StatusAtendimento statusAtendimento { get; set; }
        [Column("TOTAL_ATENDIMENTOS")] public int TotalAtendimentos { get; set; }
      


        public enum StatusAtendimento
        {
            AguardandoAtendimento = 1,
            EmAtendimento = 2,
            Atendido = 3,
            NaoAtendido = 4,
        }

        public Paciente()
        {
            ContatoEmergencia = "N/A";
        }
        
        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LabApi.Models
{
    [Table("PACIENTES")]
    public class PacienteModel : PessoaModel
    {
        [Column("ID_PACIENTE"), Required] public int IDPACIENTE { get; set; }
        [Column("CONTATO_EMERGENCIA"), Required] public string ContatoEmergencia { get; set; }
        [Column("ALERGIAS")] public string Alergias { get; set; } 
        [Column("CUIDADOS_ESPECIAIS")] public string CuidadosEspecificos { get; set; } 
        [Column("CONVENIO"), MaxLength(30)] public string Convenio { get; set; }
        [Column("STATUS_ATENDIMENTO")] public StatusAtendimento statusAtendimento { get; set; }
        [Column("TOTAL_ATENDIMENTOS")] public int TotalAtendimentos { get; set; } = 0;
        [Column ("ATENDIMENTO")] public List<AtendimentoModel> Atendimentos { get; set; }
      


        public PacienteModel()
        {
            ContatoEmergencia = "N/A";
        }
        public PacienteModel(string contatoEmergencia, string cuidadosEspecificos, StatusAtendimento statusAtendimento) 
        {
            this.ContatoEmergencia = contatoEmergencia;
            this.CuidadosEspecificos = cuidadosEspecificos;
            this.statusAtendimento = statusAtendimento;
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
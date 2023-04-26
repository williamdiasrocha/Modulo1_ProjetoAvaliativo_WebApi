using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LabApi.DTOS;

namespace LabApi.Models
{
    [Table("ATENDIMENTOS")]
    public class AtendimentoModel
    {
        [Column("ID_ATEND"), Key] public int IdAtendimento { get; set; }
        [JsonIgnore] public PacienteModel Paciente { get; set; }
        
        [JsonIgnore] public MedicoModel Medico { get; set; }
        [Column("DATA_ATEND"), Required] public DateTime DataAtendimento { get; set; }
        [ForeignKey("IdPaciente")] public int IdPaciente { get; set; }
        [Column("OBSERVACOES")] public string Observacoes { get; set; }


        public AtendimentoModel(DateTime dataAtendimento, string observacoes)
        {
            this.DataAtendimento = dataAtendimento;
            this.Observacoes = observacoes;
        }
    }
}
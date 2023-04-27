using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LabApi.DTOS;

namespace LabApi.Models
{
    [Table("ATENDIMENTOS")]
    public class AtendimentoModel
    {
        [Column("ID_ATEND"), Key]
        public int IdAtendimento { get; set; }

        
        [Column("ID_PACIENTE")]
        public int IdPaciente { get; set; }
        public PacienteModel Paciente { get; set; }

        [ForeignKey("Medico")]
        [Column("ID_MEDICO")]
        public int IdMedico { get; set; }
        public MedicoModel Medico { get; set; }

        [Column("DATA_ATEND"), Required]
        public DateTime DataAtendimento { get; set; }

        [Column("OBSERVACOES")]
        public string Observacoes { get; set; }
        
    }
}
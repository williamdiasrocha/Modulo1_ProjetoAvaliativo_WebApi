using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LabApi.DTOS;

namespace LabApi.Models
{
    [Table("ATENDIMENTOS")]
    public class AtendimentoModel
    {
        [Column("ID_ATEND"), Required] public int IdAtendimento { get; set; }
        [Column("PACIENTE")] public PacienteDTO Paciente { get; set; }
        
        [Column("MEDICO")] public MedicoDTO Medico { get; set; }
        [Column("DATA_ATEND")] public DateTime DataAtendimento { get; set; }
        [Column("LISTA_ATENDIMENTO")] public List<AtendimentoModel> Atendimentos { get; set; }
        
    }
}
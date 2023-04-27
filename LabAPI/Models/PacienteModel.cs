using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LabApi.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;

namespace LabApi.Models
{
    [Table("PACIENTES")]
    public class PacienteModel : PessoaModel
    {
        
        [Column("CONTATO_EMERGENCIA"), Required] public string ContatoEmergencia { get; set; }
        [Column("ALERGIAS")] public string Alergias { get; set; } 
        [Column("CUIDADOS_ESPECIAIS")] public string CuidadosEspecificos { get; set; } 
        [Column("CONVENIO"), MaxLength(30)] public string Convenio { get; set; }
        [ForeignKey("Status_Id")] 
        public int StatusAtendId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [Column("STATUS_ATENDIMENTO")] public StatusAtendimento statusAtendimento { get; set; }
        [Column("TOTAL_ATENDIMENTOS")] public int TotalAtendimentos { get; set; } = 0;
        [ForeignKey("Status_Id")] 
        public int StatusId { get; set; }
        
      


        public PacienteModel()
        {
            ContatoEmergencia = "N/A";
        }
       
    }    
}
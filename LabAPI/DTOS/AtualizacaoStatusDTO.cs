using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using LabApi.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static LabApi.Models.PacienteModel;

namespace LabApi.DTOS
{
    public class AtualizacaoStatusDTO
    {
        public string NovoStatus { get; set; }
        
        public StatusAtendimento StatusAtendimento { get; set; } 
        
      
       
     
        
        
    }
}
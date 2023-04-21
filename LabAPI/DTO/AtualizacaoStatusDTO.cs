using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LabAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LabAPI.DTO
{
    public class AtualizacaoStatusDTO
    {
        
        [Required]
        public string NovoStatus { get; set; }
        public List<string> OpcoesDisponiveis { get; set; }


        
        
        
        
    }
}
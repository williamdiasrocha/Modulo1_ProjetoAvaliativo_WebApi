using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LabApi.DTOS
{
    
    public class StatusAtendimentoDTO
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Status { get; set; }
        
        
        public List<string> OpcoesDisponiveis { get; set; }
       
    }
    
}
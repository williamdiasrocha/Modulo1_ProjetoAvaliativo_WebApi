using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LabApi.DTOS
{
    public class StatusAtendimentoMedicoDTO
    {
         public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Status { get; set; }
        
        
        public List<string> StatusDisponiveis { get; set; }
       
    }
     
    
}
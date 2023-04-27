using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LabApi.Enums;
using LabApi.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;

namespace LabApi.DTOS
{
    public class MedicoDTO
    {
        
      
        public string NomeMedico { get; set; }
        public string Genero { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }  
        public string InstituicaoEnsinoFormacao { get; set; }
        public string CRM_UF { get; set; }
        
        public Especializacao_Clinica Especializacao_ClinicaP {get; set; }
     
        public List<string> EspecializacaoClinica { get; set; } 
        public EstadoSistema Estado_No_Sistema { get; set; } 
        public int TotalAtendimentos { get; set; } = 0;
       
    
    public MedicoDTO()
    {
        Estado_No_Sistema = EstadoSistema.Ativo;
        Especializacao_ClinicaP = Especializacao_ClinicaP;
        EspecializacaoClinica = EspecializacaoClinica.ToList();
    }

        

        

        
    }
}
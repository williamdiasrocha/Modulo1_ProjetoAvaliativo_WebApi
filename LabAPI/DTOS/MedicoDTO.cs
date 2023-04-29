using System.ComponentModel.DataAnnotations;
using LabApi.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LabApi.DTOS
{
    public class MedicoDTO
    {
        
        public int id { get; set; }
        public string NomeMedico { get; set; }
        public string Genero { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }  
        public string InstituicaoEnsinoFormacao { get; set; }
        public string CRM_UF { get; set; }
        
        public Especializacao_Clinica Especializacao_Clinica {get; set; }
     
        public List<string> EspecializacaoClinica { get; set; } 
        
        public EstadoSistema Estado_No_Sistema { get; set; } 
        public int TotalAtendimentos { get; set; } = 0;
       
    
    public MedicoDTO()
    {
        Estado_No_Sistema = EstadoSistema.Ativo;
    }   

    

        

        
    }
}
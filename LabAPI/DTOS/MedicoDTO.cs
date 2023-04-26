using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LabApi.Models;

namespace LabApi.DTOS
{
    public class MedicoDTO
    {
        
        public int? Id { get; set; }
        public string NomeMedico { get; set; }
        public string Genero { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }  
        public string InstituicaoEnsinoFormacao { get; set; }
        public string CRM_UF { get; set; }
        [ForeignKey("Especializacao_Id")] 
        public int Especializacao_Id { get; set; }
        public List<string> EspecializacaoClinica { get; set; } 
        
        public int TotalAtendimentos { get; set; } = 0;
       
    


        public enum Especializacao_Clinica
        {
            Clinico_Geral = 1,
            Anestesista = 2,
            Dermatologia = 3,
            Ginecologia = 4,
            Neurologia = 5,
            Pediatria = 6,
            Psiquiatria = 7,
            Ortopedia = 8
        }

        public enum EstadoSistema
        {
            Inativo = 0,
            Ativo = 1
        }

        public MedicoDTO()
        {

        }

        public MedicoDTO (MedicoModel medico)
        {
            
        }
    }
}
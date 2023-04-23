using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabAPI.Models;

namespace LabAPI.DTO
{
    public class MedicoDTO
    {
        public int? Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Genero { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }  
        public string InstituicaoEnsinoFormacao { get; set; }
        public string CRM_UF { get; set; }
        public List<string> EspecializacaoClinica { get; set; } 
        public EstadoSistema Estado_No_Sistema { get; set; }
        public int TotalAtendimentos { get; set; } = 0;
        public Especializacao_Clinica Especializacao { get; set; }
        public List<AtendimentoDTO> AtendimentosMedico { get; set; }  
    


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

        public MedicoDTO (Medico medico)
        {
            
        }
        
    }
}
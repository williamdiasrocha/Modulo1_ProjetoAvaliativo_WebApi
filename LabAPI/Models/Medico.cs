using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LabAPI.Models
{
    [Table("MEDICOS")]
    public class Medico : Pessoa
    {
        [Column("INSTITUIÇÃO_ENSINO_FORMACAO"), Required] public string InstituicaoEnsinoFormacao { get; set; }
        [Column("CRM/UF"), Required] public string CRM_UF { get; set; }
        [Column("ESPECIALIZACAO_CLINICA")] public EspecializacaoClinica Especializacao_Clinica { get; set; }
        [Column("ESTADO_NO_SISTEMA")] public EstadoSistema Estado_No_Sistema { get; set; }
        [Column("TOTAL_ATENDIMENTOS"), NotNull] public int TotalAtendimentos { get; set; }

        

        public enum EspecializacaoClinica
        {
            Clinico_Geral = 1,
            Anestesista = 2,
            Dermatologia = 3,
            Ginecologia = 4,
            Neurologia = 5,
            Pediatria = 6,
            Psiquiatria = 7,
            Ortopedia = 8,
        }

        public enum EstadoSistema
        {
            Inativo,
            Ativo 
        }

        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace LabAPI.Models
{
    [Table("ENFERMEIROS")]
    public class Enfermeiro : Pessoa
    {
        [MaxLength(100)]
        [Column("INSTITUIÇÃO_ENSINO_FORMACAO"), Required] public string InstituicaoEnsinoFormacao { get; set; }
        [Column("COFEN/UF"), Required] public string COFEN_UF { get; set; }
    }
}
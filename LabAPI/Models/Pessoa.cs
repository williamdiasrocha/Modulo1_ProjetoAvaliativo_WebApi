using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace LabAPI.Models
{
    [Table("PESSOAS")]
    [Index(nameof(CPF), IsUnique = true)]
    public abstract class Pessoa
    {
        [Column("ID"), Key] public int Id { get; set; }
        [Column("NOME_COMPLETO"), Required ] public string NomeCompleto { get; set; }
        [Column("GENERO"), MaxLength(25)] public string Genero { get; set; }
        [Column("DATA_NASCIMENTO"), Required] public DateTime DataNascimento { get; set; }
        [Column("CPF"), Required] public string CPF { get; set; }
        [Column("TELEFONE"), MaxLength(15)] public string Telefone { get; set; }  
          

    }
}
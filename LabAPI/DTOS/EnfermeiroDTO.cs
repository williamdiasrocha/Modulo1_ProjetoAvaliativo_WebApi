using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LabApi.DTOS
{
    public class EnfermeiroDTO
    {
        
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Genero { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }  
        public string InstituicaoEnsinoFormacao { get; set; }
        public int TotalAtendimentos { get; set; } = 0;
        public string COFEN_UF { get; set; }
    }
}
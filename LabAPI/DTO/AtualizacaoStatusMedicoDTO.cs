using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabAPI.DTO
{
    public class AtualizacaoStatusMedicoDTO
    {
        [Required]
        public string NovoStatusM { get; set; }
        public List<string> StatusDisponiveisM { get; set; }
    }
}
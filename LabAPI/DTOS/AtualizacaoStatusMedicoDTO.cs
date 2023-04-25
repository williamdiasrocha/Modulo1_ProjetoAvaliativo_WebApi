using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabApi.DTOS
{
    public class AtualizacaoStatusMedicoDTO
    {
        public string NovoStatusM { get; set; }
        public List<string> StatusDisponiveisM { get; set; }
    }
}
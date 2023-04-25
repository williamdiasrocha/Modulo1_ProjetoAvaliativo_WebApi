using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabApi.DTOS
{
    public class AtualizacaoStatusDTO
    {
        public string NovoStatus { get; set; }
        public List<string> OpcoesDisponiveis { get; set; }
    }
}
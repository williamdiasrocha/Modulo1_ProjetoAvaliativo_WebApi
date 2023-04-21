using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabAPI.DTO
{
    public class EspecializacaoClinicaDTO
    {
        public string Descricao { get; set; }

        public EspecializacaoClinicaDTO(string descricao)
        {
            Descricao = descricao;
        }
    }
}
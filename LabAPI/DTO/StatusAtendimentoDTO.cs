using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabAPI.DTO
{
    public class StatusAtendimentoDTO
    {
        public int Id { get; set; }
        public StatusAtendimento statusAtendimento { get; set; }


   public enum StatusAtendimento
        {
            AguardandoAtendimento = 1,
            EmAtendimento = 2,
            Atendido = 3,
            NaoAtendido = 4,
        }     
        

    }
}
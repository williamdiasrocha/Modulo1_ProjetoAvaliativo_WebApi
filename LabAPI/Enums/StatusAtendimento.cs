using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LabApi.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusAtendimento
    {
        [Display(Name = "Aguardando Atendimento")]
            AguardandoAtendimento = 1,
            [Display(Name = "Em Atendimento")]
            EmAtendimento = 2,
            [Display(Name = "Atendido")]
            Atendido = 3,
            [Display(Name = "Não Atendido")]
            NaoAtendido = 4,
    }
}
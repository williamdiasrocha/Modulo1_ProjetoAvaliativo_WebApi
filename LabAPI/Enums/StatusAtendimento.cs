using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LabApi.Enums
{
    [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusAtendimento
    {
        [EnumMember(Value = "Aguardando Atendimento")]
        AguardandoAtendimento,
        [EnumMember(Value = "Em Atendimento")]
        EmAtendimento,
        [EnumMember(Value = "Atendido")]
        Atendido,
        [EnumMember(Value = "Nao Atendido")]
        NaoAtendido
        
    }
}
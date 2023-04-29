using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace LabApi.Enums
{
    [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EstadoSistema
    {
       [EnumMember(Value = "ATIVO")]
        Ativo,
        [EnumMember(Value = "INATIVO")]
        Inativo
    }
}
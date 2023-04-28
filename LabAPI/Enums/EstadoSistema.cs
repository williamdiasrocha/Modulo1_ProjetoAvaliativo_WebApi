using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LabApi.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EstadoSistema
    {
       [EnumMember(Value = "ATIVO")]
        Ativo,
        [EnumMember(Value = "INATIVO")]
        Inativo
    }
}
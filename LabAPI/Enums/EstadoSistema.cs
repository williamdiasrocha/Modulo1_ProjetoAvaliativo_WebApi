using System;
using System.Text.Json.Serialization;

namespace LabApi.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EstadoSistema
    {
        Inativo,
        Ativo 
    }
}
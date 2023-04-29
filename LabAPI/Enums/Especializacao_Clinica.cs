using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace LabApi.Enums
{
    [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Especializacao_Clinica
    {
        [EnumMember(Value = "Clinico_Geral")]
        Clinico_Geral,
        [EnumMember(Value = "Anestesista")]
        Anestesista,
        [EnumMember(Value = "Dermatologia")]
        Dermatologia,
        [EnumMember(Value = "Ginecologia")]
        Ginecologia,
        [EnumMember(Value = "Neurologia")]
        Neurologia,
        [EnumMember(Value = "Pediatria")]
        Pediatria,
        [EnumMember(Value = "Psiquiatria")]
        Psiquiatria,
        [EnumMember(Value = "Ortopedia")]
        Ortopedia

    }
}
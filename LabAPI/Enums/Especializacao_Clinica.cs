using System;
using System.Text.Json.Serialization;

namespace LabApi.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Especializacao_Clinica
    {
        Clinico_Geral = 1,
            Anestesista = 2,
            Dermatologia = 3,
            Ginecologia = 4,
            Neurologia = 5,
            Pediatria = 6,
            Psiquiatria = 7,
            Ortopedia = 8,
    }
}
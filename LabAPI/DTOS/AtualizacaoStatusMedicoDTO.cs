using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LabApi.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using static LabApi.DTOS.MedicoDTO;
using static LabApi.Models.MedicoModel;

namespace LabApi.DTOS
{
    public class AtualizacaoStatusMedicoDTO
    {
        public string NovoStatus { get; set; }
        
        public List<EstadoSistema> StatusDisponiveis { get; set; }
        
        

        public AtualizacaoStatusMedicoDTO()
        {
            StatusDisponiveis = StatusDisponiveis.ToList();
            
        }
    }
}
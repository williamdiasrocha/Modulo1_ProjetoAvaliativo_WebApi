using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LabAPI.Models;
using static LabAPI.DTO.PacienteDTO;
using LabAPI.Controllers;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;
using System.Reflection;

namespace LabAPI.DTO
{
    public class StatusAtendimentoDTO
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Status { get; set; }
        
        
        public List<string> OpcoesDisponiveis { get; set; }
       
    }
     public static class EnumHelper
    {
        public static List<string> GetDisplayNames<T>()
        {
        var enumType = typeof(T);
        var values = Enum.GetValues(enumType).Cast<T>().ToList();
        var displayNames = values.Select(value =>
        {
            var memberInfo = enumType.GetMember(value.ToString())[0];
            var displayNameAttribute = memberInfo.GetCustomAttribute<DisplayAttribute>();
            if (displayNameAttribute != null)
            {
                return displayNameAttribute.Name;
            }
            else
            {
                return value.ToString();
            }
        }).ToList();
        return displayNames;
        }
    }
   
}
   
    

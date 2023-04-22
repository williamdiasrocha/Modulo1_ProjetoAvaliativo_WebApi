using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LabAPI.DTO
{
    public class StatusAtendimentoMedicoDTO
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Status { get; set; }
        
        
        public List<string> StatusDisponiveis { get; set; }
       
    }
     public static class EnumHelperMedico
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
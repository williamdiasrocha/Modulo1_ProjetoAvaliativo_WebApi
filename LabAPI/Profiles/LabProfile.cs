using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LabAPI.DTO;
using LabAPI.Models;

namespace LabAPI.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Paciente, PacienteDTO>();
            CreateMap<Medico, MedicoDTO>();
        }
    }
}
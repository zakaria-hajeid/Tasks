using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task.Application.Dtos;
using Task.percestance.Models;

namespace Task.Application.Helpers
{
  public  class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Employee, EmployeeSimpleDto>();


            CreateMap<Employee, EmployeeFullDetailsDto>().ForMember(dest => dest.country, act => act.MapFrom(src => src.country)); 

        }
    }
}

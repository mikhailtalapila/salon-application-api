using AutoMapper;
using Salon.Data.Entities;
using Salon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.API.MappingProfiles
{
    public class EmployeeTitleMappingProfile: Profile
    {
        public EmployeeTitleMappingProfile()
        {
            CreateMap<TitleViewModel, EmployeeTitle>()
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Name));
            CreateMap<EmployeeTitle , TitleViewModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Description));
        }
    }
}

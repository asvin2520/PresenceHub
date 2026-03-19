using AutoMapper;
using Presencehub.Application.Dto;
using Presencehub.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presencehub.Application.Mapper
{
    public class PresencehubProfile : Profile
    {
        public PresencehubProfile() 
        {
            CreateMap<Role, RoleDto>().ReverseMap();
        
        }
    }
}

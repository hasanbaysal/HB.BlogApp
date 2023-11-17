using AutoMapper;
using HB.BlogApp.Dto;
using HB.BlogApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.BL.Mappings
{
    internal class AppUserMappingProfile:Profile
    {

        public AppUserMappingProfile()
        {
            CreateMap<UserCreateDto, AppUser>();
            
        }
    }
}

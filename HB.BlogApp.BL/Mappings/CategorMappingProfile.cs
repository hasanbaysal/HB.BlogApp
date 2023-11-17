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
    public class CategorMappingProfile:Profile
    {

        public CategorMappingProfile()
        {
                CreateMap<CategoryAddDto,Category>().ReverseMap();  

        }
    }
}

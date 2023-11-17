using AutoMapper;
using HB.BlogApp.BL.Services;
using HB.BlogApp.DAL.Abstracts;
using HB.BlogApp.Dto;
using HB.BlogApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.BL.Managers
{
    public class CategoryManager :
        GenericManager<CategoryAddDto, DummyUpdateDto, DummListDTO, Category>, ICategoryService
    {
        public CategoryManager(IMapper mapper, IUow uow) : base(mapper, uow)
        {
        }



    }
}

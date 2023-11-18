using AutoMapper;
using HB.BlogApp.BL.Services;
using HB.BlogApp.DAL.Abstracts;
using HB.BlogApp.Dto;
using HB.BlogApp.Entities.Entities;

namespace HB.BlogApp.BL.Managers
{
    public class BlogManager :
      GenericManager<CreateBlogDto, DummyUpdateDto, DummListDTO, Blog>, IBlogService
    {
        public BlogManager(IMapper mapper, IUow uow) : base(mapper, uow)
        {
        }

    }

}

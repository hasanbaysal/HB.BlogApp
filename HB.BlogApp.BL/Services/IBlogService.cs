using HB.BlogApp.Dto;
using HB.BlogApp.Entities.Entities;

namespace HB.BlogApp.BL.Services
{
    public interface IBlogService : IService<CreateBlogDto, DummyUpdateDto, DummListDTO, Blog>
    {

        ///

    }


}

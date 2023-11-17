using HB.BlogApp.Dto.Base;
using HB.BlogApp.Entities.Base;

namespace HB.BlogApp.BL.Services
{
    public interface IService<CreateDto,UpdateDto,ListDto,T> 
        where T : class,IBaseEntity
        where CreateDto : class, ICreateDto
        where  UpdateDto: class, IUpdateDto
        where  ListDto: class, IListDto
    {
        void Add(CreateDto dto);
        void Update(UpdateDto dto);
        void Delete(object id);
        T Get(object id);
        List<ListDto> GetAll();
    }

}

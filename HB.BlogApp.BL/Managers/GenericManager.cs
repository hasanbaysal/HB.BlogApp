using AutoMapper;
using HB.BlogApp.BL.Services;
using HB.BlogApp.DAL.Abstracts;
using HB.BlogApp.Dto.Base;
using HB.BlogApp.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.BL.Managers
{
    public class GenericManager<CreateDto, UpdateDto, ListDto, T>
        :IService<CreateDto, UpdateDto, ListDto, T>
        where T : class, IBaseEntity
        where CreateDto : class, ICreateDto
        where UpdateDto : class, IUpdateDto
        where ListDto : class, IListDto
    {
     
        protected readonly IMapper _mapper; 
        protected readonly IUow  _uow;

        public GenericManager(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public void Add(CreateDto dto)
        {
            //
           var entity =  _mapper.Map<T>(dto);

            _uow.GetRepository<T>().Add(entity);
            _uow.SaveChanges();

        

        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public T Get(object id)
        {
            throw new NotImplementedException();
        }

        public List<ListDto> GetAll()
        {
            
            throw new NotImplementedException();
        }

        public void Update(UpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

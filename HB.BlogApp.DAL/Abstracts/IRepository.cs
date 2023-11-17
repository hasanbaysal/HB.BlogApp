using HB.BlogApp.Entities.Base;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.DAL.Abstracts
{
    public interface IRepository<T> where T : IBaseEntity 
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> GetQueryable();

        List<T> GetAll(bool asnoTracking = true);
        List<T> GetAll(Expression<Func<T,bool>> filter);
        T? Get(Expression<Func<T, bool>> filter);
        T? Get(object id);
       

    }

}

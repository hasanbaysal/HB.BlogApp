using HB.BlogApp.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.DAL.Abstracts
{
    public interface IUow
    {

        void SaveChanges();
        public IRepository<T> GetRepository<T>() where T : class,IBaseEntity;

    }
}

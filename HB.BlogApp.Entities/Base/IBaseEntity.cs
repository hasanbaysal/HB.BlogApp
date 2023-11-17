using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.Entities.Base
{
    public interface IBaseEntity
    {
    }

    public interface IBaseEntity<T>:IBaseEntity where T:class
    {
        public T Id { get; set; }
    }
}

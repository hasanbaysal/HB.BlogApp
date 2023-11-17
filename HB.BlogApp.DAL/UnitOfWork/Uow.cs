using HB.BlogApp.DAL.Abstracts;
using HB.BlogApp.DAL.Contexts;
using HB.BlogApp.DAL.Repository;
using HB.BlogApp.Entities.Base;
using HB.BlogApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.DAL.UnitOfWork
{
    public class Uow : IUow
    {

        //bu arkadaş DI container'a kayıt edilecek

        private readonly AppDbContext _context;

        public Uow(AppDbContext context)
        {
            //DI
            _context = context;
        }

        public void SaveChanges()
        {
           _context.SaveChanges();
        }

        IRepository<T> IUow.GetRepository<T>()
        {
            return new GenericRepository<T>(_context);
        }

       


    }



    
}

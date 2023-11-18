using HB.BlogApp.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.Dto
{
    public class CreateBlogDto:ICreateDto
    {
        public string Title { get; set; } = null!;
        public string Context { get; set; } = null!;
        public string ImagePath { get; set; } = null!;
        public int CategoryId { get; set; }
    }


  
}

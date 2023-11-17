using HB.BlogApp.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.Dto
{

  
    public class CategoryAddDto:ICreateDto
    {
        public string CategoryName { get; set; } = null!;
    }
}

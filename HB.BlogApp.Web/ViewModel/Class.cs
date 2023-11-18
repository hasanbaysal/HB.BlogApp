using HB.BlogApp.BL.Managers;
using HB.BlogApp.BL.Services;

namespace HB.BlogApp.Web.ViewModel
{
  
    public class CreateBlogViewmode
    {
        public string Title { get; set; } = null!;
        public string Context { get; set; } = null!;
        public IFormFile İmage { get; set; } = null!;
        public int CategoryId { get; set; }

    }
}

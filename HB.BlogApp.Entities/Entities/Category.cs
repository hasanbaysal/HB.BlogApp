using HB.BlogApp.Entities.Base;

namespace HB.BlogApp.Entities.Entities
{
    public class Category: IBaseEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public List<Blog> Blogs { get; set; } = new();
    }
}

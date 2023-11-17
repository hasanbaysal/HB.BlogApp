using HB.BlogApp.Entities.Base;

namespace HB.BlogApp.Entities.Entities
{
    public class Blog: IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Context { get; set; } = null!;
        public string ImagePath { get; set; } = null!;


        //nav props and fk
        public List<UserFavBlog> UserFavBlogs { get; set; } = new();
        public List<Comment> Comments { get; set; } = new();

        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}

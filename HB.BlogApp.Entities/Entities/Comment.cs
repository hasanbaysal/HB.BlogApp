using HB.BlogApp.Entities.Base;

namespace HB.BlogApp.Entities.Entities
{
    //cross table  appuser with blog (n-n relation)
    public class Comment : IBaseEntity
    {

        public int Id { get; set; }

        public string CommentContent { get; set; } = null!;
        public DateTime AddedDate { get; set; }


        //nav prop
        public AppUser AppUser { get; set; }
        public Blog Blog { get; set; }


        //FK => bu senaryoda bir bloga  aynı userın birden çok yorum atma ihtimaline karşı bu iki foregin birleşimini PK yapmadık!!!!

        public string UserId { get; set; } = null!;
        public int BlogId { get; set; }

        public bool Status { get; set; } = true;
        public string? CommentAddIP { get; set; }

    }

}

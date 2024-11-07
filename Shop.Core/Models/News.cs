namespace Shop.Core.Models
{
    public class News
    {        
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public long UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}

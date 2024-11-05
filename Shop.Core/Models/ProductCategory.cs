namespace Shop.Core.Models
{
    public class ProductCategory
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public long? ParentId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}

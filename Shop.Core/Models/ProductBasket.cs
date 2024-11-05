namespace Shop.Core.Models
{
    public class ProductBasket
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long ProductId { get; set; }

        public int Count { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}

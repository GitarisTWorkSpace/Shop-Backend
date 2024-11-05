namespace Shop.Core.Models
{
    public class PaymentMethod
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}

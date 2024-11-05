namespace Shop.Core.Models
{
    public class Transaction
    {
        public long Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public long StatusId { get; set; }

        public decimal Amount { get; set; }

        public long CheckoutId { get; set; }

        public object? ProviderData { get; set; }
    }
}

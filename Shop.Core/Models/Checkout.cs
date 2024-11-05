namespace Shop.Core.Models
{
    public class Checkout
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long RecipientId { get; set; }

        public List<ProductBasket> ProductBaskets { get; set; }

        public long PaymentMethodId { get; set; }

        public long DeliveryMethodId { get; set; }

        public decimal PaymentTotal { get; set; }
    }
}

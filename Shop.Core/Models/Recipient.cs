namespace Shop.Core.Models
{
    public class Recipient
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}

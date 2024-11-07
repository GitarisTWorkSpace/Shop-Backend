namespace Shop.Core.Models
{
    public class User
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string? Surname { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        // зависимости
        public List<LoginCode> LoginCode { get; set; }
    }
}

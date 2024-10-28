namespace Shop.Core.Models
{
    public class User
    {
        public long Id { get; set; }

        public string Alias { get; set; }

        public string? Name { get; set; }

        public string? LastName { get; set; }  
        
        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}

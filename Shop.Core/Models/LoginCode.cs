namespace Shop.Core.Models
{
    public class LoginCode
    {
        public long Id { get; set; }

        public long UserId { get; set; }        

        public string Code { get; set; }

        public DateTime CreatedAt { get; set; }

        // зависимости
        public User User { get; set; }
    }
}

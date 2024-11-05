namespace Shop.Api.Contracts.User
{
    public record UserCodeConfirmRequest(string email, string code);
}

namespace Shop.Api.Contracts.User
{
    public record RegistrationUserRequest(string Name, string? Surname, string email, string? phoneNumber);
}

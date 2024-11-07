namespace Shop.Api.Contracts.User
{
    public record RegistrationUserRequest(string name, string? surname, string email, string? phoneNumber);
}

namespace SecureApi.Web.Models;

public class User
{
    public Guid Id { get; init; }
    public required string UserName { get; init; }
    public Password Password { get; set; }
    public required string Email { get; set; }
    public bool IsEmailVerified { get; set; }
}

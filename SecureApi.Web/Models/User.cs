namespace SecureApi.Web.Models;

public class User
{
    public Guid Id { get; init; }
    public required string UserName { get; init; }
    public Password Password { get; set; }
    public Email Email { get; set; }
}

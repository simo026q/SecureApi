namespace SecureApi.Web.Services.Email;

public class EmailMessage
{
    public required string RecipientEmail { get; init; }
    public required string RecipientName { get; init; }
    public required string Subject { get; init; }
    public required string Body { get; init; }
}

namespace SecureApi.Web.Services.Email;

public interface IEmailClient
{
    Task SendAsync(EmailMessage message);
}

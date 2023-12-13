namespace SecureApi.Web.Models;

public class UserDevice
{
    public Guid Id { get; init; }
    public required string IpAddress { get; init; }
    public string? UserAgent { get; init; }
    public string? Language { get; init; }
    public string? Referrer { get; init; }
    public string? SecBrand { get; init; }
    public bool SecIsMobile { get; init; }
    public string? SecPlatform { get; init; }
    public string? SecPlatformVersion { get; init; }
    public string? SecModel { get; init; }
    public DateTimeOffset LastUsedAt { get; set; }
    public DateTimeOffset CreatedAt { get; init; }
}

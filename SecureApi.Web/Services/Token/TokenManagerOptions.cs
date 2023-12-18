namespace SecureApi.Web.Services.Token;

public sealed class TokenManagerOptions
{
    public required string Issuer { get; init; }
    public required string Audience { get; init; }
    public required string Key { get; init; }
    public TimeSpan LifeSpan { get; init; }
}

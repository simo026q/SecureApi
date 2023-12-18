namespace SecureApi.Web.Models;

public readonly struct EmailAddress
    : IEquatable<EmailAddress>
{
    public string Value { get; }
    public bool IsVerified { get; }

    public EmailAddress(string value, bool isVerified)
    {
        Value = value;
        IsVerified = isVerified;
    }

    public bool Equals(EmailAddress other)
    {
        return Value == other.Value && IsVerified == other.IsVerified;
    }

    public override bool Equals(object? obj)
    {
        return obj is EmailAddress other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, IsVerified);
    }

    public static bool operator ==(EmailAddress left, EmailAddress right) => left.Equals(right);
    public static bool operator !=(EmailAddress left, EmailAddress right) => !left.Equals(right);
}

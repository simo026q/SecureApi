namespace SecureApi.Web.Models;

public readonly struct Email
    : IEquatable<Email>
{
    public string Value { get; }
    public bool IsVerified { get; }

    public Email(string value, bool isVerified)
    {
        Value = value;
        IsVerified = isVerified;
    }

    public bool Equals(Email other)
    {
        return Value == other.Value && IsVerified == other.IsVerified;
    }

    public override bool Equals(object? obj)
    {
        return obj is Email other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, IsVerified);
    }

    public static bool operator ==(Email left, Email right) => left.Equals(right);
    public static bool operator !=(Email left, Email right) => !left.Equals(right);
}

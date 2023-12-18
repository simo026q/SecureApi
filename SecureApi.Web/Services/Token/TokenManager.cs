using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SecureApi.Web.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SecureApi.Web.Services.Token;

public class TokenManager
    : ITokenManager
{
    private static readonly JwtSecurityTokenHandler TokenHandler = new();

    private readonly TokenManagerOptions _options;
    private readonly SigningCredentials _signingCredentials;

    public TokenManager(IOptions<TokenManagerOptions> options)
    {
        _options = options.Value;

        _signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key)), SecurityAlgorithms.HmacSha512Signature);
    }

    public string CreateToken(User user, UserDevice device)
    {
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(CreateClaims(user, device)),
            Expires = DateTime.UtcNow + _options.LifeSpan,
            SigningCredentials = _signingCredentials,
        };

        var token = TokenHandler.CreateToken(tokenDescriptor);

        return TokenHandler.WriteToken(token);
    }

    private static IEnumerable<Claim> CreateClaims(User user, UserDevice device)
    {
        return
        [
            new("id", user.Id.ToString()),
            new("username", user.UserName),
            new("email", user.Email.Value, ClaimValueTypes.Email),
            new("email_verified", user.Email.IsVerified.ToString(), ClaimValueTypes.Boolean),
            new("device", device.Id.ToString())
        ];
    }
}

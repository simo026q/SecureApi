using SecureApi.Web.Models;

namespace SecureApi.Web.Services.Token;

public interface ITokenManager
{
    string CreateToken(User user, UserDevice device);
}

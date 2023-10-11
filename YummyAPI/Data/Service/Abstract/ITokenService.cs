using System.Security.Claims;
using YummyAPI.Models;

namespace YummyAPI.Data.Service.Abstract
{
    public interface ITokenService
    {

        TokenResponse GetToken(IEnumerable<Claim> claims);

        string GetRefreshToken();

        ClaimsPrincipal GetPrincipalfromExpireToken(string Token);
    }
}

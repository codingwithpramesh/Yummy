using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyAPI.Data;
using YummyAPI.Data.Service.Abstract;
using YummyAPI.Models;

namespace YummyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   /* [Authorize]*/
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _service;
        private readonly ApplicationDbContext _context;
        public TokenController( ITokenService service , ApplicationDbContext context)
        {
            _context = context;
            _service = service;
        }

        [HttpPost]
        public IActionResult Refresh(RefreshTokenRequest tokenApiModel)
        {
            if (tokenApiModel is null)
                return BadRequest("Invalid client request");
            string accessToken = tokenApiModel.AccessToken;
            string refreshToken = tokenApiModel.RefreshToken;
            var principal = _service.GetPrincipalfromExpireToken(accessToken);
            var username = principal.Identity.Name;
            var user = _context.Tokens.SingleOrDefault(u => u.Name == username);
            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiry <= DateTime.Now)
                return BadRequest("Invalid client request");
            var newAccessToken = _service.GetToken(principal.Claims);
            var newRefreshToken = _service.GetRefreshToken();
            user.RefreshToken = newRefreshToken;
            _context.SaveChanges();
            return Ok(new RefreshTokenRequest()
            {
                AccessToken = newAccessToken.TokenString,
                RefreshToken = newRefreshToken
            });
        }

    }
}

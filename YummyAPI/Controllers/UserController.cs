using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using YummyAPI.Data;
using YummyAPI.Data.Enum;
using YummyAPI.Data.Service.Abstract;
using YummyAPI.Data.Service.Implementation;
using YummyAPI.Models;

namespace YummyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ITokenService _service;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;


        public UserController(ITokenService service, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager , ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager; 
            _roleManager = roleManager;
            _service = service;
            _context = context;
        }

        [HttpPost ("Login")]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var token = _service.GetToken(authClaims);
                var refreshToken = _service.GetRefreshToken();
                var tokenInfo = _context.Tokens.FirstOrDefault(a => a.Name == user.UserName);
                if (tokenInfo == null)
                {
                    var info = new TokenInfo
                    {
                        Name = user.UserName,
                        RefreshToken = refreshToken,
                        RefreshTokenExpiry = DateTime.Now.AddDays(1)
                    };
                    _context.Tokens.Add(info);
                }

                else
                {
                    tokenInfo.RefreshToken = refreshToken;
                    tokenInfo.RefreshTokenExpiry = DateTime.Now.AddDays(1);
                }
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                return Ok(new LoginResponse
                {
                    Name = user.Name,
                    Username = user.UserName,
                    Token = token.TokenString,
                    RefreshToken = refreshToken,
                    Expiration = token.ValidTo,
                    StatusCode = 1,
                    Message = "Logged in"
                });

            }

            return Ok(
                new LoginResponse
                {
                    StatusCode = 0,
                    Message = "Invalid Username or Password",
                    Token = "",
                    Expiration = null
                });
        }


        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "User");
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterModel register)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass all the required fields";
                return Ok(status);
            }
            // check if user exists
            var userExists = await _userManager.FindByEmailAsync(register.Email);
            if (userExists!=null)
            {
                
                status.StatusCode = 0;
                status.Message = "Invalid username";
                return Ok(status);
            }
            var user = new ApplicationUser
            {
                UserName = register.Name,
                Name = register.Name,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = register.Email,
               Role = register.Role,
              
            };
           
            var result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "User creation failed";
                return Ok(status);
            }
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            status.StatusCode = 1;
            status.Message = "Sucessfully registered";
            return Ok(status);

        }
    


        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword()
        {
            return Ok();
        }

    }
}

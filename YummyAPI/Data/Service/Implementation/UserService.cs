using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YummyAPI.Data.Service.Abstract;
using YummyAPI.Models;

namespace YummyAPI.Data.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public UserService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager , RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _context=context;

        }

        [HttpPost]
        public void Login(string Username, string Password)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void Logout()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void Register(RegisterModel register)
        {
            throw new NotImplementedException();
        }
    }
}

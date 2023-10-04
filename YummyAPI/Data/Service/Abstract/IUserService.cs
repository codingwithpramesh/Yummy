using YummyAPI.Models;

namespace YummyAPI.Data.Service.Abstract
{
    public interface IUserService
    {

        public void Login(string Username , string Password);

        public void Logout();

        public void Register(RegisterModel register);

    }
}

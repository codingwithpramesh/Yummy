using Microsoft.Win32;
using YummyAPI.Models;

namespace YummyAPI.Data.Service.Abstract
{
    public interface IUserService
    {

        Task LoginAsync(LoginModel login);

        Task Registration (RegisterModel register);

      

        

    }
}

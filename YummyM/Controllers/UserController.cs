using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using YummyM.Models;

namespace YummyM.Controllers
{
    public class UserController : Controller
    {

        Uri baseAddress = new Uri("https://localhost:7115/api/");
        private readonly HttpClient _httpClient;
        public UserController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

     

        [HttpPost, ActionName("Register")]
        public async Task<IActionResult> RegisteredAsync( RegisterModel Register)
        {

            string url = baseAddress + "User/Register";
            var content = new StringContent(JsonConvert.SerializeObject(Register), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(Register);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ActionName("Login")]
        public async Task<IActionResult> LoginedAsync(LoginModel login) 
        {
            string url = baseAddress + "user/login" ;
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                LoginModel userViewModel = JsonConvert.DeserializeObject<LoginModel>(jsonResponse);
                return View(userViewModel);
            }
            return NotFound();
        }
        
    }
}

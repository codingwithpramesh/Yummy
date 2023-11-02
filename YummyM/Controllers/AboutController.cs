using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyM.Models;

namespace YummyM.Controllers
{
    public class AboutController : Controller
    {

        Uri baseAddress = new Uri("https://localhost:7115/api/");
        private readonly HttpClient _httpClient;

        public AboutController()
        {
            _httpClient = new HttpClient();
        }
        public async Task<IActionResult> Index()
        {
          /*  string url = baseAddress+ "EcomPortfolio/Index";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string JsonResponse = await response.Content.ReadAsStringAsync();
                List<EcomPortfolioVM> users = JsonConvert.DeserializeObject<List<abou>>(JsonResponse);
                return View(users);
            }
            return View(new List<ContactVM>()); */
            return View(); 


        }
    }
}


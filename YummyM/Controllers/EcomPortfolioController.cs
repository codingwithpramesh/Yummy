using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using YummyM.Models;

namespace YummyM.Controllers
{
    public class EcomPortfolioController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7115/api/");
        private readonly HttpClient _httpClient;
        public EcomPortfolioController()
        {
            _httpClient = new HttpClient();
        }
        public async Task<IActionResult> IndexAsync()
        {
            string url = baseAddress+ "Book/Index";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string JsonResponse = await response.Content.ReadAsStringAsync();

                List<EcomPortfolioVM> users = JsonConvert.DeserializeObject<List<EcomPortfolioVM>>(JsonResponse);
                return View(users);
            }
            return View(new List<ContactVM>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(EcomPortfolioVM ecom, IFormFile file)
        {
            string url = baseAddress + "Ecomportfolio/Create";
            var content = new StringContent(JsonConvert.SerializeObject(ecom), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(ecom);
        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            string url = $"{baseAddress}user/Update/?id="+ id;
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                EcomPortfolioVM userViewModel = JsonConvert.DeserializeObject<EcomPortfolioVM>(jsonResponse);
                return View(userViewModel);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Guid id, ContactVM userViewModel)
        {
            string url = $"{baseAddress}User/"+ id;
            var content = new StringContent(JsonConvert.SerializeObject(userViewModel), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(userViewModel);
        }

        [HttpGet]
        [Route("Product/DeleteData")]
        public async Task<IActionResult> DeleteData(Guid id)
        {
            string url = baseAddress + "User/"+ id;
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                ContactVM userViewModel = JsonConvert.DeserializeObject<ContactVM>(jsonResponse);
                return View(userViewModel);
            }


            return NotFound();
        }



        [HttpDelete("{id:Guid}"), ActionName("DeleteData")]
        [Route("Product/DeleteData")]
        public async Task<IActionResult> Delete(Guid id)
        {
            string url = $"{baseAddress}User/"+ id;
            HttpResponseMessage response = await _httpClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Delete), new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            string url = baseAddress + "user/" + id;
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                EcomPortfolioVM ecom = JsonConvert.DeserializeObject<EcomPortfolioVM>(jsonResponse);
                return View(ecom);
            }


            return NotFound();
        }
    }
}

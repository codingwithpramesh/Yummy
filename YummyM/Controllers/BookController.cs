using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using YummyM.Models;

namespace YummyM.Controllers
{
    public class BookController : Controller
    {

        Uri baseAddress = new Uri("https://localhost:7115/api/");
        private readonly HttpClient _httpClient;

        public BookController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            string url = baseAddress+ "Book/GetAll";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string JsonResponse = await response.Content.ReadAsStringAsync();

                List<BookVM> users = JsonConvert.DeserializeObject<List<BookVM>>(JsonResponse);
                return View(users);
            }
            return View(new List<BookVM>());
        }

        [HttpGet]
        public  IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(BookVM bookvm)
        {
            string url = baseAddress + "Book/Create";
            StringContent content = new StringContent(JsonConvert.SerializeObject(bookvm), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(bookvm);
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            string url = $"{baseAddress}Book/Update/?id="+ id;
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                BookVM userViewModel = JsonConvert.DeserializeObject<BookVM>(jsonResponse);
                return View(userViewModel);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, BookVM userViewModel)
        {
            string url = $"{baseAddress}book/update/?id="+ id;
            var content = new StringContent(JsonConvert.SerializeObject(userViewModel), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(userViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            string url = baseAddress + "Book/Details?id="+ id;
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                BookVM userViewModel = JsonConvert.DeserializeObject<BookVM>(jsonResponse);
                return View(userViewModel);
            }
            return NotFound();
        }



        [HttpDelete, ActionName("Delete")]
        [Route("Book/Delete/{id}")]
        public async Task<IActionResult> Deleted(int id)
        {
            string url = $"{baseAddress}Book/Delete?id="+ id;
            HttpResponseMessage response = await _httpClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Delete), new { id = id });
        }



        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            string url = baseAddress + "Book/Details?id=" + id;
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                BookVM userViewModel = JsonConvert.DeserializeObject<BookVM>(jsonResponse);
                return View(userViewModel);
            }


            return NotFound();
        }

    }
}

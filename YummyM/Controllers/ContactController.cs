using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using YummyM.Models;

namespace YummyM.Controllers
{
    public class ContactController : Controller
    {

        Uri baseAddress = new Uri("https://localhost:7115/");
        private readonly HttpClient _httpClient;

        public ContactController()
        {
            _httpClient = new HttpClient();
        }
        public async Task<IActionResult> IndexAsync()
        {
            string url = baseAddress+ "Index";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string JsonResponse = await response.Content.ReadAsStringAsync();

                List<ContactVM> users = JsonConvert.DeserializeObject<List<ContactVM>>(JsonResponse);
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
        public async Task<IActionResult> Create(ContactVM contact)
        {
            string url = baseAddress + "Create";
            var content = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(contact);
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            string url = $"{baseAddress}Details?id="+ id;
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                ContactVM userViewModel = JsonConvert.DeserializeObject<ContactVM>(jsonResponse);
                return View(userViewModel);
            }
            return NotFound();
        }

        [HttpPost]
       /* [ValidateAntiForgeryToken]*/
        public async Task<IActionResult> Update(int id, ContactVM userViewModel)
        {
            string url = $"{baseAddress}Update?id="+ id;
            var content = new StringContent(JsonConvert.SerializeObject(userViewModel), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(userViewModel);
        }

        [HttpGet]
        [Route("contact/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            string url = baseAddress + "Details?id=" + id;
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                ContactVM userViewModel = JsonConvert.DeserializeObject<ContactVM>(jsonResponse);
                return View(userViewModel);
            }


            return NotFound();
        }



        [HttpDelete]
        [Route("contact/Delete")]
        public async Task<IActionResult> Deleted(int id)
        {
            string url = $"{baseAddress}Delete?id="+ id;
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
            string url = baseAddress + "Details?id=" + id;
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                ContactVM userViewModel = JsonConvert.DeserializeObject<ContactVM>(jsonResponse);
                return View(userViewModel);
            }


            return NotFound();
        }
    }
}

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
            string url = baseAddress + "contact/Create";
            var content = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(contact);
        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            string url = $"{baseAddress}user/Update/?id="+ id;
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
                ContactVM userViewModel = JsonConvert.DeserializeObject<ContactVM>(jsonResponse);
                return View(userViewModel);
            }


            return NotFound();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using YummyM.Models;

namespace YummyM.Controllers
{
    public class EventController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7115/api/");
        private readonly HttpClient _httpClient;
        public EventController( ) 
        {
            _httpClient = new HttpClient();
        }
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            string url = baseAddress+ "Event/GetAll";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string JsonResponse = await response.Content.ReadAsStringAsync();

                List<EventVM> events = JsonConvert.DeserializeObject<List<EventVM>>(JsonResponse);
                return View(events);
            }
            return View(new List<EventVM>());
        }

        public  IActionResult CreateAsync()
        {
            return View();
        }

        public async Task<IActionResult> Create(EventVM eventvm)
        {
            string url = baseAddress + "Event/Create";
            var multipartContent = new MultipartContent();
           
            HttpResponseMessage response = await _httpClient.PostAsync(url, multipartContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(eventvm);
        }




    }
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using YummyM.Models;
namespace YummyM.Controllers
{
    public class EventController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7115/api/");
        private readonly HttpClient _httpClient;

        private readonly IWebHostEnvironment _environment;
        public EventController(IWebHostEnvironment environment)
        {
            _environment = environment;
            _httpClient = new HttpClient();
        }
      
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {

            string url = baseAddress+ "Event/Index";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string JsonResponse = await response.Content.ReadAsStringAsync();
                List<EventVM> events = JsonConvert.DeserializeObject<List<EventVM>>(JsonResponse);

                return View(events);
            }
            return View(new List<EventVM>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /* [HttpPost]
         public async Task<IActionResult> Create(EventVM eventvm)
         {
             string url = baseAddress + "Event/Create";
             if (eventvm.ImageEvent != null)
             {
                 FileSaveAsync(eventvm.ImageEvent);
                 using (var httpClient = new HttpClient())
                 {
                     using (var multipartContent = new MultipartFormDataContent())
                     {
                         var streamContent = new StreamContent(eventvm.ImageEvent.OpenReadStream());
                         streamContent.Headers.ContentType = new MediaTypeHeaderValue(eventvm.ImageEvent.ContentType);
                         multipartContent.Add(streamContent, "EventImage", eventvm.ImageEvent.FileName);


                         multipartContent.Add(new StringContent(eventvm.eventtitle ?? string.Empty), "Eventtitle");
                         multipartContent.Add(new StringContent(eventvm.EventPrice.ToString() ?? string.Empty), "EventPrice");
                         multipartContent.Add(new StringContent(eventvm.eventDescrip ?? string.Empty), "eventDescrip");
                         multipartContent.Add(new StringContent(eventvm.eventDescription ?? string.Empty), "eventDescription");
                         HttpResponseMessage response = await httpClient.PostAsync(url, multipartContent);
                         if (response.IsSuccessStatusCode)
                         {
                             return RedirectToAction(nameof(Index));
                         }
                         else
                         {
                             ModelState.AddModelError(string.Empty, "Error uploading the image.");
                             return View(eventvm);
                         }
                     }
                 }
             }
             else
             {
                 ModelState.AddModelError("ImageEvent", "Please select an image to upload.");
                 return View(eventvm);
             }
         }
 */



        [HttpPost]
        public async Task<IActionResult> Create(EventVM eventvm)
        {
            try
            {
                string url = baseAddress+"Event/Create";
                string data = JsonConvert.SerializeObject(eventvm);
                StringContent content = new StringContent(data , Encoding.UTF8, "application/Json");
                HttpResponseMessage Response = _httpClient.PostAsync(url, content).Result;
                if(Response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Product Created";
                    return RedirectToAction("Index");
                }
            }catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
            return View();


           /* string url = baseAddress+ "Event/Create";
            using (var multipartContent = new MultipartFormDataContent())
            {
                var streamContent = new StreamContent(eventvm.ImageEvent.OpenReadStream());
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(eventvm.ImageEvent.ContentType);
                multipartContent.Add(streamContent, "EventImage", eventvm.ImageEvent.FileName);
                multipartContent.Add(new StringContent(eventvm.eventtitle ?? string.Empty), "Eventtitle");
                multipartContent.Add(new StringContent(eventvm.EventPrice.ToString() ?? string.Empty), "EventPrice");
                multipartContent.Add(new StringContent(eventvm.eventDescrip ?? string.Empty), "eventDescrip");
                multipartContent.Add(new StringContent(eventvm.eventDescription ?? string.Empty), "eventDescription");
                HttpResponseMessage response = await _httpClient.PostAsync(url, multipartContent);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error uploading the image.");
                    return View(eventvm);
                }
            }
*/
        }

        [HttpGet]
        public async Task<IActionResult> Update(EventVM eventVM)
        {
            /* string url = baseAddress+"Event/Update";
             MultipartContent multipartContent = new MultipartContent();
             if (eventVM.ImageEvent != null)
             {
                 StreamContent streamContent = new StreamContent(eventVM.ImageEvent.OpenReadStream());
                 streamContent.Headers.ContentType = new MediaTypeHeaderValue(eventVM.ImageEvent.ContentType);
               //  multipartContent.Add(streamContent, "EventImage", eventVM.ImageEvent.FileName);
             }
             HttpResponseMessage response = await _httpClient.GetAsync(url);
             if (response.IsSuccessStatusCode)
             {
                 string jsonResponse = await response.Content.ReadAsStringAsync();
                 EventVM userViewModel = JsonConvert.DeserializeObject<EventVM>(jsonResponse);
                 return View(userViewModel);
             }
             return NotFound();*/
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, EventVM eventvm)
        {
            /*string url = baseAddress+"event/Update"+ id;
            MultipartContent multipartcontent = new MultipartContent();
            if(eventvm.ImageEvent != null)
            {
                StreamContent streamContent = new StreamContent(eventvm.ImageEvent.OpenReadStream());
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(eventvm.ImageEvent.ContentType);
               // multipartcontent.Add(streamContent, "EventImage", eventvm.ImageEvent.FileName);

            }
            var content = new StringContent(JsonConvert.SerializeObject(eventvm), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(eventvm);*/

            return View();
        }

        [HttpGet]
        [Route("Event/Delete")]
        public async Task<IActionResult> DeleteData(int id)
        {
            /*  string url = baseAddress + "Event/Delete"+ id;
              HttpResponseMessage response = await _httpClient.GetAsync(url);

              if (response.IsSuccessStatusCode)
              {
                  string jsonResponse = await response.Content.ReadAsStringAsync();
                  EventVM events = JsonConvert.DeserializeObject<EventVM>(jsonResponse);
                  return View(events);
              }
              return NotFound();*/

            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            /*string url = baseAddress+"Event/Delete/";
            HttpResponseMessage response = await _httpClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Delete), new { id = id });*/
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
           /* string url = baseAddress + "Event/Details" + id;
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                EventVM events = JsonConvert.DeserializeObject<EventVM>(jsonResponse);
                return View(events);
            }
            return NotFound();*/

            return View();
        }

        private async Task FileSaveAsync(IFormFile file)
        {

            string wwwroot = _environment.WebRootPath;
            var filepath = Path.Combine(wwwroot, "Images", file.FileName);
            using (var fileStream = new FileStream(filepath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

        }
    }
}

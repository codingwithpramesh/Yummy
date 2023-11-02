using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using YummyM.Models;
using System.Net.Http.Headers;
namespace YummyM.Controllers
{
    public class GalleryController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7115/api/");
        private readonly HttpClient _httpClient;
        private readonly IWebHostEnvironment _environment;
        public GalleryController( IWebHostEnvironment environment)
        {
            _environment = environment;
           _httpClient  =  new HttpClient();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            string url = baseAddress+ "Gallery/Index";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string JsonResponse = await response.Content.ReadAsStringAsync();
                List<GalleryVM> events = JsonConvert.DeserializeObject<List<GalleryVM>>(JsonResponse);
                return View(events);
            }
            return View(new List<EventVM>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(GalleryVM galleryvm)
        {
            try
            {
                string url = baseAddress + "Gallery/Create";
                FileSave(galleryvm.ImageGallery);
                using (var multipartContent = new MultipartFormDataContent())
                {
                    if (galleryvm.ImageGallery != null)
                    {
                        using (var streamContent = new StreamContent(galleryvm.ImageGallery.OpenReadStream()))
                        {
                            streamContent.Headers.ContentType = new MediaTypeHeaderValue(galleryvm.ImageGallery.ContentType);
                            multipartContent.Add(streamContent, "GalleryImage", galleryvm.ImageGallery.FileName);
                        }
                    }
                    using (HttpResponseMessage response = await _httpClient.PostAsync(url, multipartContent))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                        
                            return RedirectToAction(nameof(Index));
                        }
                        
                    }
                }

                return View(galleryvm);
            }
            catch (Exception ex)
            {
               
                return View(galleryvm);
            }
        }


        /*   [HttpPost]
           public async Task<IActionResult> Create(GalleryVM galleryvm)
           {
               string url = baseAddress + "Gallery/Create";
               var multipartContent = new MultipartContent();
               if (galleryvm.ImageGallery != null)
               {
                   StreamContent streamcontent =  new StreamContent(galleryvm.ImageGallery.OpenReadStream());
                   streamcontent.Headers.ContentType = new MediaTypeHeaderValue(galleryvm.ImageGallery.ContentType);
                   multipartContent.Add(streamcontent, "GalleryImage", galleryvm.ImageGallery.FileName);
               }
               HttpResponseMessage response = await _httpClient.PostAsync(url, multipartContent);
               if (response.IsSuccessStatusCode)
               {
                   return RedirectToAction(nameof(Index));
               }

               return View(galleryvm);
           }*/

        [HttpGet]
        public async Task<IActionResult> Update(GalleryVM galleryvm)
        {
            string url = baseAddress+"Gallery/Update";
            MultipartContent multipartContent = new MultipartContent();
            if (galleryvm.ImageGallery != null)
            {
                StreamContent streamContent = new StreamContent(galleryvm.ImageGallery.OpenReadStream());
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(galleryvm.ImageGallery.ContentType);
              //  multipartContent.Add(streamContent, "GalleryImage", galleryvm.ImageGallery.FileName);
            }
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                EventVM userViewModel = JsonConvert.DeserializeObject<EventVM>(jsonResponse);
                return View(userViewModel);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, GalleryVM galleryvm)
        {
            string url = baseAddress+"Gallery/Update"+ id;

            MultipartContent multipartcontent = new MultipartContent();
            if (galleryvm.ImageGallery != null)
            {
                StreamContent streamContent = new StreamContent(galleryvm.ImageGallery.OpenReadStream());
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(galleryvm.ImageGallery.ContentType);
               // multipartcontent.Add(streamContent, "GalleryImage", galleryvm.ImageGallery.FileName);

            }
            var content = new StringContent(JsonConvert.SerializeObject(galleryvm), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(galleryvm);
        }

        [HttpGet]
        [Route("Event/Delete")]
        public async Task<IActionResult> DeleteData(int id)
        {
            string url = baseAddress + "Gallery/Delete"+ id;
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                GalleryVM Galleryvm = JsonConvert.DeserializeObject<GalleryVM>(jsonResponse);
                return View(Galleryvm);
            }
            return NotFound();
        }


        public async Task<IActionResult> Delete(int id)
        {
            string url = baseAddress+"Gallery/Delete/";
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
            string url = baseAddress + "Gallery/Details" + id;
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                GalleryVM galleryvm = JsonConvert.DeserializeObject<GalleryVM>(jsonResponse);
                return View(galleryvm);
            }
            return NotFound();
        }


        private async Task FileSave(IFormFile file)
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

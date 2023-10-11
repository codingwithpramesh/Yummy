using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Text;
using YummyM.Models;

namespace YummyM.Controllers
{
    public class EcomPortfolioController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7115/api/");
        private readonly HttpClient _httpClient;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EcomPortfolioController( IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpClient = new HttpClient();
        }
        public async Task<IActionResult> IndexAsync()
        {
            _httpClient.Timeout = TimeSpan.FromSeconds(1000);
            string url = baseAddress+ "EcomPortfolio/Index";
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
        public async Task<IActionResult> Create(EcomPortfolioVM ecom)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string url = baseAddress + "EcomPortfolio/Create";
                    var multipartContent = new MultipartFormDataContent();
                    if (ecom.ImageAbout != null)
                    {
                        StreamContent streamContent = new StreamContent(ecom.ImageAbout.OpenReadStream());
                        streamContent.Headers.ContentType = new MediaTypeHeaderValue(ecom.ImageAbout.ContentType);
                        multipartContent.Add(streamContent, "AboutImage", ecom.ImageAbout.FileName);
                    }
                    if (ecom.Imagechef != null)
                    {
                        var streamContent = new StreamContent(ecom.Imagechef.OpenReadStream());
                        streamContent.Headers.ContentType = new MediaTypeHeaderValue(ecom.Imagechef.ContentType);
                        multipartContent.Add(streamContent, "chefImage", ecom.Imagechef.FileName);
                    }
                    if (ecom.ImageEvent != null)
                    {
                        var streamContent = new StreamContent(ecom.ImageEvent.OpenReadStream());
                        streamContent.Headers.ContentType = new MediaTypeHeaderValue(ecom.ImageEvent.ContentType);
                        multipartContent.Add(streamContent, "EventImage", ecom.ImageEvent.FileName);
                    }
                    if (ecom.ImageGallery != null)
                    {
                        var streamContent = new StreamContent(ecom.ImageGallery.OpenReadStream());
                        streamContent.Headers.ContentType = new MediaTypeHeaderValue(ecom.ImageGallery.ContentType);
                        multipartContent.Add(streamContent, "GalleryImage", ecom.ImageGallery.FileName);
                    }

                    if (ecom.VideosAbout != null)
                    {
                        var streamContent = new StreamContent(ecom.VideosAbout.OpenReadStream());
                        streamContent.Headers.ContentType = new MediaTypeHeaderValue(ecom.VideosAbout.ContentType);
                        multipartContent.Add(streamContent, "AboutVideos", ecom.VideosAbout.FileName);
                    }


                    
                    //StringContent content = new StringContent(JsonConvert.SerializeObject(ecom));
                    multipartContent.Add(new StringContent(ecom.HeroTitle), "HeroTitle");
                    multipartContent.Add(new StringContent(ecom.HeroDescription), "HeroDescription");
                    multipartContent.Add(new StringContent(ecom.HeroButton), "HeroButton");
                    multipartContent.Add(new StringContent(ecom.AboutTitle), "AboutTitle");
                    multipartContent.Add(new StringContent(ecom.AboutDescription), "AboutDescription");
                    /*multipartContent.Add(new StringContent(ecom.CardTitle), "CardTitle");
                    multipartContent.Add(new StringContent(ecom.CardDescription), "CardDescription");
                    multipartContent.Add(new StringContent(ecom.CardButtonText), "CardButtonText");
                    multipartContent.Add(new StringContent(ecom.TotalClient), "TotalClient");
                    multipartContent.Add(new StringContent(ecom.totalProject), "totalProject");
                    multipartContent.Add(new StringContent(ecom.TotalHours), "TotalHours");
                    multipartContent.Add(new StringContent(ecom.TotalWorkers), "TotalWorkers");
                    multipartContent.Add(new StringContent(ecom.MenuTitle), "MenuTitle");
                    multipartContent.Add(new StringContent(ecom.Menuvalue), "Menuvalue");
                    multipartContent.Add(new StringContent(ecom.TimeCategory.ToString()), "TimeCategory");
                    multipartContent.Add(new StringContent(ecom.professorTitle), "professorTitle");

                    multipartContent.Add(new StringContent(ecom.ProfessorDescription), "HeroTitle");
                    multipartContent.Add(new StringContent(ecom.HeroDescription), "HeroDescription");
                    multipartContent.Add(new StringContent(ecom.HeroButton), "HeroButton");
                    multipartContent.Add(new StringContent(ecom.AboutTitle), "AboutTitle");
                    multipartContent.Add(new StringContent(ecom.AboutDescription), "AboutDescription");
                    multipartContent.Add(new StringContent(ecom.CardTitle), "CardTitle");
                    multipartContent.Add(new StringContent(ecom.CardDescription), "CardDescription");
                    multipartContent.Add(new StringContent(ecom.CardButtonText), "CardButtonText");
                    multipartContent.Add(new StringContent(ecom.TotalClient), "TotalClient");
                    multipartContent.Add(new StringContent(ecom.totalProject), "totalProject");
                    multipartContent.Add(new StringContent(ecom.TotalHours), "TotalHours");
                    multipartContent.Add(new StringContent(ecom.TotalWorkers), "TotalWorkers");
                    multipartContent.Add(new StringContent(ecom.MenuTitle), "MenuTitle");
                    multipartContent.Add(new StringContent(ecom.Menuvalue), "Menuvalue");
                    multipartContent.Add(new StringContent(ecom.TimeCategory.ToString()), "TimeCategory");
                    multipartContent.Add(new StringContent(ecom.professorTitle), "professorTitle");*/
                    if (ecom.ImageAbout != null)
                    {
                        multipartContent.Add(new StringContent(ecom.ImageAbout.FileName), "ImageAbout");
                    }
                    multipartContent.Add(new StringContent(ecom.AboutDescription), "AboutDescription");
                   
         

                    /*         multipartContent.Add(new StringContent(ecom.CardDescription), "CardDescription");
                             multipartContent.Add(new StringContent(ecom.HeroDescription), "HeroDescription");
                             multipartContent.Add(new StringContent(ecom.HeroTitle), "HeroTitle");
                             multipartContent.Add(new StringContent(ecom.HeroDescription), "HeroDescription");*/
                    HttpResponseMessage response = await _httpClient.PostAsync(url, multipartContent);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception e)
                {
                    ViewBag.error = e;
                    return View(e);
                }
            }

            return View(ecom);

        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            string url = $"{baseAddress}Ecomportfolio/Update";
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
        public async Task<IActionResult> Update(int id, EcomPortfolioVM ecom)
        {
            string url = $"{baseAddress}User/"+ id;
            var content = new StringContent(JsonConvert.SerializeObject(ecom), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(ecom);
        }

        [HttpGet]
        [Route("Product/DeleteData")]
        public async Task<IActionResult> DeleteData(int id)
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




        public async Task<IActionResult> Delete(int id)
        {
            string url = $"{baseAddress}Ecomportfolio/";
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
            string url = baseAddress + "Ecomportfolio/Details/" + id;
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

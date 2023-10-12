using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
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
                    multipartContent.Add(new StringContent(ecom.HeroTitle ?? string.Empty), "HeroTitle");
                    multipartContent.Add(new StringContent(ecom.HeroDescription ?? string.Empty), "HeroDescription");
                    multipartContent.Add(new StringContent(ecom.HeroButton ?? string.Empty), "HeroButton");
                    multipartContent.Add(new StringContent(ecom.AboutTitle ?? string.Empty), "AboutTitle");
                    multipartContent.Add(new StringContent(ecom.AboutDescription ?? string.Empty), "AboutDescription");
                    multipartContent.Add(new StringContent(ecom.CardTitle ?? string.Empty), "CardTitle");
                    multipartContent.Add(new StringContent(ecom.CardDescription ?? string.Empty), "CardDescription");
                    multipartContent.Add(new StringContent(ecom.CardButtonText?? string.Empty), "CardButtonText");
                    multipartContent.Add(new StringContent(ecom.TotalClient ?? string.Empty), "TotalClient");
                    multipartContent.Add(new StringContent(ecom.totalProject ?? string.Empty), "totalProject");
                    multipartContent.Add(new StringContent(ecom.TotalHours ?? string.Empty), "TotalHours");
                    multipartContent.Add(new StringContent(ecom.TotalWorkers ?? string.Empty), "TotalWorkers");
                    multipartContent.Add(new StringContent(ecom.MenuTitle ?? string.Empty), "MenuTitle");
                    multipartContent.Add(new StringContent(ecom.Menuvalue ?? string.Empty), "Menuvalue");
                    multipartContent.Add(new StringContent(ecom.TimeCategory.ToString() ?? string.Empty), "TimeCategory");
                    multipartContent.Add(new StringContent(ecom.professorTitle ?? string.Empty), "professorTitle");
                    multipartContent.Add(new StringContent(ecom.ProfessorDescription ?? string.Empty), "HeroTitle");
                    multipartContent.Add(new StringContent(ecom.HeroDescription ?? string.Empty), "HeroDescription");
                    multipartContent.Add(new StringContent(ecom.HeroButton ?? string.Empty), "HeroButton");
                    multipartContent.Add(new StringContent(ecom.AboutTitle ?? string.Empty), "AboutTitle");
                    multipartContent.Add(new StringContent(ecom.AboutDescription ?? string.Empty), "AboutDescription");
                    multipartContent.Add(new StringContent(ecom.CardTitle ?? string.Empty), "CardTitle");
                    multipartContent.Add(new StringContent(ecom.CardDescription ?? string.Empty), "CardDescription");
                    multipartContent.Add(new StringContent(ecom.CardButtonText ?? string.Empty), "CardButtonText");
                    multipartContent.Add(new StringContent(ecom.TotalClient ?? string.Empty), "TotalClient");
                    multipartContent.Add(new StringContent(ecom.totalProject ?? string.Empty), "totalProject");
                    multipartContent.Add(new StringContent(ecom.TotalHours ??string.Empty), "TotalHours");
                    multipartContent.Add(new StringContent(ecom.TotalWorkers ?? string.Empty), "TotalWorkers");
                    multipartContent.Add(new StringContent(ecom.MenuTitle ?? string.Empty), "MenuTitle");
                    multipartContent.Add(new StringContent(ecom.Menuvalue ?? string.Empty), "Menuvalue");
                    multipartContent.Add(new StringContent(ecom.TimeCategory.ToString() ?? string.Empty), "TimeCategory");
                    multipartContent.Add(new StringContent(ecom.professorTitle ?? string.Empty), "professorTitle");
                    multipartContent.Add(new StringContent(ecom.professorName ?? string.Empty), "professorName");
                    multipartContent.Add(new StringContent(ecom.ProfessorPosition ?? string.Empty), "ProfessorPosition");
                    multipartContent.Add(new StringContent(ecom.ProfessorRating ?? string.Empty), "ProfessorRating");
                    multipartContent.Add(new StringContent(ecom.eventtitle ?? string.Empty), "eventtitle");
                    multipartContent.Add(new StringContent(ecom.eventDescription ?? string.Empty), "eventDescription");
                    multipartContent.Add(new StringContent(ecom.EventPrice ?? string.Empty), "EventPrice");
                    multipartContent.Add(new StringContent(ecom.eventDescrip ?? string.Empty), "eventDescrip");
                    multipartContent.Add(new StringContent(ecom.chefTitle ?? string.Empty), "chefTitle");
                    multipartContent.Add(new StringContent(ecom.chefName ?? string.Empty), "chefName");
                    multipartContent.Add(new StringContent(ecom.ChefPosition ?? string.Empty), "ChefPosition");
                    multipartContent.Add(new StringContent(ecom.ChefDescription ??string.Empty), "ChefDescription");
                    multipartContent.Add(new StringContent(ecom.GalleryTitle ?? string.Empty), "GalleryTitle");
                    multipartContent.Add(new StringContent(ecom.ContactTitle ?? string.Empty), "ContactTitle");
                    multipartContent.Add(new StringContent(ecom.ContactDescription ?? string.Empty), "ContactDescription");
                    multipartContent.Add(new StringContent(ecom.contactEmail ?? string.Empty), "contactEmail");
                    multipartContent.Add(new StringContent(ecom.contactAddress ?? string.Empty), "contactAddress");
                    multipartContent.Add(new StringContent(ecom.Phone ?? string.Empty), "Phone");
                    multipartContent.Add(new StringContent(ecom.OpeningHour ?? string.Empty), "OpeningHour");
                    multipartContent.Add(new StringContent(ecom.FooterAddress ?? string.Empty), "FooterAddress");
                    multipartContent.Add(new StringContent(ecom.FooterPhone ?? string.Empty), "FooterPhone");
                    multipartContent.Add(new StringContent(ecom.FooterEmail ??string.Empty), "FooterEmail");
                    multipartContent.Add(new StringContent(ecom.FooterOpeningHour ?? string.Empty), "FooterOpeningHour");

                    /*  await using var stream = System.IO.File.OpenRead("./Test.txt");
                      *//*string filepath = @"D:\Yummy\Yummy\YummyAPI\wwwroot\Images\"; *//*
                      string filename = Path.GetFileName(ecom.ImageAbout.ToString());
                      if (ecom.ImageAbout != null)
                      {

                          multipartContent.Add(new StreamContent(stream), "ImageAbout", "Test.txt");
                      }*/

                   /* if(ecom.ImageAbout.FileName != null)
                    {

                    }*/
                   
                    var fileroute = @"D:\API Documentation.pdf";
                    var fileroute1 = @"D:\API Documentation.pdf";
                    var tech = @"D:\API Documentation.pdf";
                    var group = @"D:\API Documentation.pdf";
                    var final = @"D:\API Documentation.pdf";


                    var filename = Path.GetFileName(fileroute);
                    using var FileStream = System.IO.File.OpenRead(fileroute);

                    var filename1 = Path.GetFileName(fileroute1);
                    using var FileStream1 = System.IO.File.OpenRead(fileroute1);

                    var filename2 = Path.GetFileName(tech);
                    using var FileStream2 = System.IO.File.OpenRead(tech);

                    var filename3 = Path.GetFileName(group);
                    using var FileStream3 = System.IO.File.OpenRead(group);

                    var filename4 = Path.GetFileName(final);
                    using var FileStream4 = System.IO.File.OpenRead(final);

                    multipartContent.Add(new StreamContent(FileStream), "ImageAbout" ,filename);
                   multipartContent.Add(new StreamContent(FileStream1), "VideosAbout", filename1);
                    multipartContent.Add(new StreamContent(FileStream2), "ImageEvent", filename2);
                    multipartContent.Add(new StreamContent(FileStream3), "Imagechef", filename3);
                    multipartContent.Add(new StreamContent(FileStream4), "ImageGallery", filename4);
                    multipartContent.Add(new StringContent(ecom.AboutDescription ?? string.Empty), "AboutDescription");
                   
         

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


        private async Task FileSave(IFormFile file)
        {
            string wwwroot = _webHostEnvironment.WebRootPath;
            var filepath = Path.Combine(wwwroot, "Files" , file.FileName);
            using (var fileStream = new FileStream(filepath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            
        }
    }
}

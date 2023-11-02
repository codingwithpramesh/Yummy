using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Pipes;
using System.Net.Http;
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
        public EcomPortfolioController(IWebHostEnvironment webHostEnvironment)
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
                   await FileSaveAsync(ecom.ImageAbout);
                   await FileSaveAsync(ecom.Imagechef);
                    /*foreach (var data in ecom.ImageEvent)
                    {
                      await  FileSaveAsync(data);
                    }*/
                  /*  foreach (var data in ecom.ImageGallery)
                    {
                      await  FileSaveAsync(data);
                    }*/
                    await FileSaveAsync(ecom.VideosAbout);
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
                   /* if (ecom.ImageEvent != null && ecom.ImageEvent.Count > 0)
                    {
                        int index = 0;
                        foreach (var imageEvent in ecom.ImageEvent)
                        {
                            var streamContent = new StreamContent(imageEvent.OpenReadStream());
                            streamContent.Headers.ContentType = new MediaTypeHeaderValue(imageEvent.ContentType);
                            multipartContent.Add(streamContent, "imageEvent"+index, imageEvent.FileName);
                            index++;
                        }
                    }*/
                    /*if (ecom.ImageGallery != null &&ecom.ImageGallery.Count>0)
                    {
                        int index = 0;
                        foreach (var galleryImage in ecom.ImageGallery)
                        {
                            var streamContentGallery = new StreamContent(galleryImage.OpenReadStream());
                            streamContentGallery.Headers.ContentType = new MediaTypeHeaderValue(galleryImage.ContentType);
                            multipartContent.Add(streamContentGallery, "ImageGallery"+index, galleryImage.FileName);
                            index++;
                        }
                    }*/

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
                    multipartContent.Add(new StringContent(ecom.professorTitle ?? string.Empty), "professorTitle");
                    multipartContent.Add(new StringContent(ecom.professorName ?? string.Empty), "professorName");
                    multipartContent.Add(new StringContent(ecom.ProfessorPosition ?? string.Empty), "ProfessorPosition");
                    multipartContent.Add(new StringContent(ecom.ProfessorRating ?? string.Empty), "ProfessorRating");
                    /*multipartContent.Add(new StringContent(ecom.eventtitle ?? string.Empty), "eventtitle");
                    multipartContent.Add(new StringContent(ecom.eventDescription ?? string.Empty), "eventDescription");
                    multipartContent.Add(new StringContent(ecom.EventPrice ?? string.Empty), "EventPrice");
                    multipartContent.Add(new StringContent(ecom.eventDescrip ?? string.Empty), "eventDescrip");*/
                    multipartContent.Add(new StringContent(ecom.chefTitle ?? string.Empty), "chefTitle");
                    multipartContent.Add(new StringContent(ecom.chefName ?? string.Empty), "chefName");
                    multipartContent.Add(new StringContent(ecom.ChefPosition ?? string.Empty), "ChefPosition");
                    multipartContent.Add(new StringContent(ecom.ChefDescription ??string.Empty), "ChefDescription");
                   // multipartContent.Add(new StringContent(ecom.GalleryTitle ?? string.Empty), "GalleryTitle");
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
                    multipartContent.Add(new StringContent(ecom.AboutDescription ?? string.Empty), "AboutDescription");
                    if (ecom.ImageAbout != null)
                    {
                        string file = ecom.ImageAbout.FileName;
                        string path = Directory.GetCurrentDirectory();
                        string Fullpath = Path.Combine(path+ "\\wwwroot\\Images\\"+ file);
                        var FileStream = System.IO.File.OpenRead(Fullpath);
                        multipartContent.Add(new StreamContent(FileStream), "ImageAbout", file);
                    }
                    if (ecom.Imagechef != null)
                    {
                        string file = ecom.Imagechef.FileName;
                        string path = Directory.GetCurrentDirectory();
                        string Fullpath = Path.Combine(path+ "\\wwwroot\\Images\\"+ file);
                        var FileStream = System.IO.File.OpenRead(Fullpath);
                        multipartContent.Add(new StreamContent(FileStream), "Imagechef", file);
                    }

/*
                    if (ecom.ImageEvent!= null && ecom.ImageEvent.Any())
                    {
                        foreach (var imageEvent in ecom.ImageEvent)
                        {
                            string file = imageEvent.FileName;
                            string path = Directory.GetCurrentDirectory();
                            string fullpath = Path.Combine(path, "wwwroot", "Images", file);


                            if (System.IO.File.Exists(fullpath))
                            {
                                var fileStream = System.IO.File.OpenRead(fullpath);
                                multipartContent.Add(new StreamContent(fileStream), "ImageEvent", file);
                            }
                        }
                    }*/
                  /*  if (ecom.ImageGallery != null && ecom.ImageGallery.Any())
                    {
                        foreach (var galleryImage in ecom.ImageGallery)
                        {
                            string file = galleryImage.FileName;
                            string path = Directory.GetCurrentDirectory();
                            string fullpath = Path.Combine(path, "wwwroot", "Images", file);


                            if (System.IO.File.Exists(fullpath))
                            {
                                using (var fileStream = System.IO.File.OpenRead(fullpath))
                                {
                                    new StreamContent(fileStream).Headers.ContentType = new MediaTypeHeaderValue(file);
                                    multipartContent.Add(new StreamContent(fileStream), "ImageGallery", file);
                                }
                            }
                        }
                    }*/


                    if (ecom.VideosAbout != null)
                    {
                        string file = ecom.VideosAbout.FileName;
                        string path = Directory.GetCurrentDirectory();
                        string Fullpath = Path.Combine(path+ "\\wwwroot\\Images\\"+ file);
                        var FileStream = System.IO.File.OpenRead(Fullpath);
                        multipartContent.Add(new StreamContent(FileStream), "VideosAbout", file);
                    }
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
        public async Task<IActionResult> Edit(int id)
        {
            string url = $"{baseAddress}EcomPortfolio/Update?id="+ id;
           
            MultipartContent multipartContent = new MultipartContent();
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
        public async Task<IActionResult> Edit(int id, EcomPortfolioVM ecom)
        {
            string url = $"{baseAddress}EcomPortfolio/Update?id="+ id;
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
            string url = baseAddress + "EcomPortfolio/Delete/"+ id;
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
            string url = $"{baseAddress}EcomPortfolio/Delete/" + id;
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


        private async Task FileSaveAsync(object files)
        {
            if (files is IFormFile singleFile)
            {
               await SaveFileAsync(singleFile);
            }
            else if (files is IEnumerable<IFormFile> multipleFiles)
            {
                foreach (var file in multipleFiles)
                {
                    await SaveFileAsync(file);
                }
            }
        }

        private async Task SaveFileAsync(IFormFile file)
        { 
            string wwwroot = _webHostEnvironment.WebRootPath;
            var filepath = Path.Combine(wwwroot, "Images", file.FileName);
            using (var fileStream = new FileStream(filepath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
        }

    }
}

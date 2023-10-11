﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using YummyM.Models;

namespace YummyM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Uri baseAddress = new Uri("https://localhost:7115/api/");
        private readonly HttpClient _httpClient;
        public HomeController(ILogger<HomeController> logger )
        {
            _httpClient = new HttpClient();
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            string url = baseAddress + "Home/Home";
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                EcomPortfolioVM userViewModel = JsonConvert.DeserializeObject<EcomPortfolioVM>(jsonResponse);
                return View(userViewModel);
            }
            return NotFound();
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
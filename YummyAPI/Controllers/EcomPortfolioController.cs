using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YummyAPI.Data.Service.Abstract;
using YummyAPI.Models.ViewModel;
using YummyAPI.Models;
using Microsoft.AspNetCore.Hosting;
using YummyAPI.Data;

namespace YummyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcomPortfolioController : ControllerBase
    {

       private readonly IEcomPortFolioService _service;
       private readonly ApplicationDbContext _context;
       private readonly IWebHostEnvironment _environment;
        public EcomPortfolioController(IEcomPortFolioService service , ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _service = service;
            _context = context;
            _environment = environment;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            var data = _service.GetAll();
            return Ok(data);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync( [FromForm] EcomPortfolio? ecom)
        { 
            try
            {
                string wwwRootPath = _environment.WebRootPath;
                if (ecom.ImageAbout != null)
                    await SaveFileAsync(ecom.ImageAbout, wwwRootPath, "/Images/", "AboutImage");

                if (ecom.VideosAbout != null)
                    await SaveFileAsync(ecom.VideosAbout, wwwRootPath, "/Videos/", "AboutVideos");

                if (ecom.ImageEvent != null)
                    await SaveFileAsync(ecom.ImageEvent, wwwRootPath, "/Images/", "EventImage");

                if (ecom.Imagechef != null)
                    await SaveFileAsync(ecom.Imagechef, wwwRootPath, "/Images/", "ChefImage");

                if (ecom.ImageGallery != null && ecom.ImageGallery.Count > 0)
                {
                    foreach (var img in ecom.ImageGallery)
                    {
                        await SaveFileAsync(img, wwwRootPath, "/Images/", "GalleryImage");
                    }
                }
                await _context.ecomPortfolios.AddAsync(ecom);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return Ok();




        }

        [HttpPut("Update")]
        public IActionResult Update(int id, ContactVM contactVm)
        {
            /*var data = _context.Contacts.Find(id);
            if (data != null)
            {
                data.Name = contactVm.Name;
                data.Email = contactVm.Email;
                data.Subject = contactVm.Subject;
                data.Message = contactVm.Message;
            }
            return NotFound();*/
            return Ok();
        }


        [HttpGet("Update")]
        public async Task<IActionResult> Update(int id)
        {
            /*var data = await _context.Contacts.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);*/
            return Ok();
        }


        [HttpDelete("Delete")]

        public IActionResult Delete(int id)
        {
            /*var data = _context.Contacts.Find(id);
            if (data != null)
            {
                _context.Contacts.Remove(data);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();*/
            return Ok();
        }


        [HttpGet("Details")]

        public IActionResult Details([FromRoute] int id)
        {
           
            return Ok();
        }

        private async Task SaveFileAsync(IFormFile file, string rootPath, string directory, string property)
        {
            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string extension = Path.GetExtension(file.FileName);
            string fullPath = Path.Combine(rootPath + directory+ fileName + DateTime.Now.ToString("yymmssfff") + extension);

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
        }




    }
}

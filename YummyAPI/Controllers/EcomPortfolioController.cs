using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YummyAPI.Data.Service.Abstract;
using YummyAPI.Models.ViewModel;
using YummyAPI.Models;
using Microsoft.AspNetCore.Hosting;
using YummyAPI.Data;
using Microsoft.AspNetCore.Authorization;
namespace YummyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   /* [Authorize]*/
    public class EcomPortfolioController : ControllerBase
    {

       // private readonly IEcomPortFolioService _service;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public EcomPortfolioController(/*IEcomPortFolioService service,*/ ApplicationDbContext context, IWebHostEnvironment environment)
        {
           // _service = service;
            _context = context;
            _environment = environment;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            var data = _context.ecomPortfolios.ToList();
            return Ok(data);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] EcomPortfolio ecom )
        {
            try
            {
                List<string> allFilePaths = new List<string>();
                string wwwRootPath = _environment.WebRootPath;
                if (ecom.ImageAbout != null)
                    await SaveFileAsync(ecom.ImageAbout, wwwRootPath, "/Images/", "AboutImage", ecom);

                if (ecom.VideosAbout != null)
                    await SaveFileAsync(ecom.VideosAbout, wwwRootPath, "/Videos/", "AboutVideos", ecom);

               /* foreach (var imagevents in ecom.ImageEvent)
                {   
                        await SaveFileAsync(imagevents, wwwRootPath, "/Images/", "EventImage", ecom);
                }*/

                if (ecom.Imagechef != null)
                    await SaveFileAsync(ecom.Imagechef, wwwRootPath, "/Images/", "ChefImage", ecom);

              /*  foreach(var gallaries in ecom.ImageGallery)
                {
                        await SaveFileAsync(gallaries, wwwRootPath, "/Images/", "GalleryImage", ecom);
                }*/

                await _context.ecomPortfolios.AddAsync(ecom);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }


        [HttpGet("Update")]
        public async Task<IActionResult> Update(int id)
        {
            var data = await _context.ecomPortfolios.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);

        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromForm] EcomPortfolio updatedEcom)
        {
            try
            {
                string wwwRootPath = _environment.WebRootPath;
                var existingEcom = await _context.ecomPortfolios.FindAsync(updatedEcom.Id);
                if (existingEcom == null)
                {
                    return NotFound("EcomPortfolio not found.");
                }

                if (updatedEcom.ImageAbout != null)
                    await SaveFileAsync(updatedEcom.ImageAbout, wwwRootPath, "/Images/", "AboutImage" , updatedEcom);

                if (updatedEcom.VideosAbout != null)
                    await SaveFileAsync(updatedEcom.VideosAbout, wwwRootPath, "/Videos/", "AboutVideos",updatedEcom);

                foreach(var items in updatedEcom.ImageEvent)
                {
                    if (updatedEcom.ImageEvent != null)
                        await SaveFileAsync(items, wwwRootPath, "/Images/", "EventImage", updatedEcom);

                }
                if (updatedEcom.Imagechef != null)
                    await SaveFileAsync(updatedEcom.Imagechef, wwwRootPath, "/Images/", "ChefImage", updatedEcom);

                _context.ecomPortfolios.Update(updatedEcom);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var ecomToDelete = await _context.ecomPortfolios.FindAsync(id);
                if (ecomToDelete == null)
                {
                    return NotFound("EcomPortfolio not found.");
                }
                string wwwRootPath = _environment.WebRootPath;
                DeleteFile(wwwRootPath + "/Images/" + ecomToDelete.AboutImage);
                DeleteFile(wwwRootPath + "/Videos/" + ecomToDelete.AboutVideos);
                _context.ecomPortfolios.Remove(ecomToDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }

            return Ok();
        }


        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var ecomDetails = await _context.ecomPortfolios.FindAsync(id);
                if (ecomDetails == null)
                {
                    return NotFound("EcomPortfolio not found.");
                }
                return Ok(ecomDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        private void DeleteFile(string path)
        {
            try
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting file at {path}. Exception: {ex.ToString()}");
            }
        }

        private async Task SaveFileAsync(IFormFile file, string rootPath, string directory, string property, EcomPortfolio ecom)
        {
            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string extension = Path.GetExtension(file.FileName);
            string fullPath = Path.Combine(rootPath + directory+ fileName + DateTime.Now.ToString("yymmssfff") + extension);

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            switch(property)
            {
                case "AboutImage":
                    ecom.AboutImage = directory + fileName + extension;
                    break;
                case "AboutVideos":
                    ecom.AboutVideos = directory + fileName + extension;
                    break;
                /*case "EventImage":
                    if (ecom.EventImage == null)
                    {
                        ecom.EventImage = directory + fileName + extension;
                    }
                    else
                    {
                        ecom.EventImage += ","+ directory + fileName + extension; 
                    }
                    break;*/
                case "ChefImage":
                    ecom.ChefImage = directory + fileName + extension;
                    break;
               /* case "GalleryImage":

                    if (ecom.GalleryImage == null)
                    {
                        ecom.GalleryImage = directory + fileName + extension;
                    }
                    else
                    {
                        ecom.GalleryImage += ","+ directory + fileName + extension;
                    }
                    break;*/
                default:
                    break;

            }
        }




    }
}

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using YummyAPI.Data.Service.Abstract;
using YummyAPI.Models;
namespace YummyAPI.Data.Service.Implementation
{
    public class EcomPortFolioService : IEcomPortFolioService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EcomPortFolioService(ApplicationDbContext context , IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _context=context;
        }

       /* public async Task<EcomPortfolio> AddAsync(EcomPortfolio ecom, IFormFile AboutImage,IFormFile abou)
        {
            string? fileName = Path.GetFileNameWithoutExtension(AboutImage?.FileName);
            string extension = Path.GetExtension(AboutImage?.FileName ?? string.Empty);
            ecom.AboutImage = @"\Images\" + (fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension);
            string path = Path.Combine(  "/Images/", fileName);
            if (AboutImage != null)
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await AboutImage?.CopyToAsync(fileStream);
                }
            }

            await _context.ecomPortfolios.AddAsync(ecom);
            await _context.SaveChangesAsync();
            return ecom;
        }*/

        public async Task DeleteAsync(int id)
        {
            var data = _context.Events.FirstOrDefault(x => x.Id == id);
            if (data == null)
            {
                throw new ArgumentException($"No event found with ID {id}");
            }
            if (!string.IsNullOrEmpty(data.EventImage))
            {
                string wwwroot = _webHostEnvironment.WebRootPath;
                string filepath = Path.Combine(wwwroot, "Images", data.EventImage);

                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
            }
            _context.Events.Remove(data);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<EcomPortfolio> GetAll()
        {
            var data = _context.ecomPortfolios.ToList();
            return data;
        }

        public EcomPortfolio GetById(int id)
        {
            throw new NotImplementedException();
        }

        public EcomPortfolio update(EcomPortfolio ecom)
        {
            throw new NotImplementedException();
        }

        public async Task<EcomPortfolio> AddAsync(EcomPortfolio ecom, IFormFile file)
        {
            try
            {

                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string? fileName = Path.GetFileNameWithoutExtension(file?.FileName);
                string extension = Path.GetExtension(file?.FileName);
                ecom.AboutImage = @"\Images\" + (fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension);
                string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                if (file != null)
                {


                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await file?.CopyToAsync(fileStream);
                    }
                }

                await _context.ecomPortfolios.AddAsync(ecom);
                await _context.SaveChangesAsync();
                return ecom;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

     

        /* [HttpPost("Add")]
         public async Task AddAsync(EcomPortfolio ecom , IFormFile file)
         {
              var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
             if (!Directory.Exists(uploads))
             {
                 Directory.CreateDirectory(uploads);
             }
             var filePath = Path.Combine(uploads, file.FileName);

             using (var fileStream = new FileStream(filePath, FileMode.Create))
             {
                 await file.CopyToAsync(fileStream);
             }

             // Now, save the path (or a relevant part of it) to your database in the appropriate property
             var contentItem = await _context.ecomPortfolios.FirstOrDefaultAsync(); // Replace with appropriate logic


             switch (ecom.GalleryImage.ToLower() || ecom.EventImage.ToLower() ||  ecom.ChefImage.ToLower() ||  ecom.AboutImage.ToLower() || ecom.AboutVideos.ToLower())
             {
                 case "aboutimage":
                     contentItem.AboutImage = filePath;
                     break;
                 case "eventimage":
                     contentItem.EventImage = filePath;
                     break;
                 case "chefimage":
                     contentItem.ChefImage = filePath;
                     break;
                 case "galleryimage":
                     contentItem.GalleryImage = filePath;
                     break;
                 default:
                     return BadRequest("Unknown property.");
             }

             _context.ecomPortfolios.Update(contentItem);
             await _context.SaveChangesAsync();

             return Ok(new { Path = filePath });
         }

         public void Delete(int id)
         {
             throw new NotImplementedException();
         }

         public IEnumerable<EcomPortfolio> GetAll()
         {
             throw new NotImplementedException();
         }

         public EcomPortfolio GetById(int id)
         {
             throw new NotImplementedException();
         }

         public EcomPortfolio update(EcomPortfolio ecom)
         {
             throw new NotImplementedException();
         }

     }

         [HttpDelete("Delete")]
         public void Delete(int id)
         {
             EcomPortfolio data = _context.ecomPortfolios.Where(re => re.Id == id).FirstOrDefault();
             _context.ecomPortfolios.Remove(data);
             _context.SaveChanges();
         }


         [HttpGet("GetAll")]
         public IEnumerable<EcomPortfolio> GetAll()
         {
             IEnumerable<EcomPortfolio> data = _context.ecomPortfolios.ToList();
             return data;
         }


         [HttpGet("GetById")]
         public EcomPortfolio GetById(int id)
         {
             EcomPortfolio data = _context.ecomPortfolios.FirstOrDefault(x => x.Id == id);
             return data;
         }

         [HttpPost("update")]
         public EcomPortfolio update(EcomPortfolio ecom)
         {
             _context.ecomPortfolios.Update(ecom);
             _context.SaveChanges(true);
             return ecom;
         }*/
    }
}




using Microsoft.EntityFrameworkCore;
using YummyAPI.Data.Service.Abstract;
using YummyAPI.Models;

namespace YummyAPI.Data.Service.Implementation
{
    public class GalleryService : IGalleryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public GalleryService(ApplicationDbContext context , IWebHostEnvironment environment) 
        {
            _environment = environment;
           _context = context;
        }

        public async Task<Gallery> Add(Gallery gallery, IFormFile file)
        {
            string wwwroot = _environment.WebRootPath;
            string? fileName = Path.GetFileNameWithoutExtension(gallery.ImageGallery?.FileName);
            string extension = Path.GetExtension(gallery.ImageGallery?.FileName ?? string.Empty);
            gallery.GalleryImage = @"\Images\" + (fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension);
            string path = Path.Combine(wwwroot+"/Images/", fileName);
            if (gallery.ImageGallery != null)
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await gallery.ImageGallery?.CopyToAsync(fileStream);
                }
            }

             await _context.Galleries.AddAsync(gallery);
            await _context.SaveChangesAsync();
            return gallery;

            
        }

        public async Task Delete(int id)
        {
            var data = _context.Events.FirstOrDefault(x => x.Id == id);
            if (data == null)
            {
                throw new ArgumentException($"No event found with ID {id}");
            }
            if (!string.IsNullOrEmpty(data.EventImage))
            {
                string wwwroot = _environment.WebRootPath;
                string filepath = Path.Combine(wwwroot, "Images", data.EventImage);

                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
            }
             _context.Events.Remove(data);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Gallery> GetAll()
        {
            var data = _context.Galleries.ToList();
            return data;
        }

        public Gallery GetById(int id)
        {
          var data = _context.Galleries.FirstOrDefault(x => x.Id == id);
            return data;
        }

        public Task<Gallery> update(Gallery gallery)
        {
            throw new NotImplementedException();
        }
    }
}

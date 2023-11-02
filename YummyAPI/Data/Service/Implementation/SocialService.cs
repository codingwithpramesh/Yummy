using YummyAPI.Data.Service.Abstract;
using YummyAPI.Models;

namespace YummyAPI.Data.Service.Implementation
{
    public class SocialService : ISocialMedia
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public SocialService( ApplicationDbContext context , IWebHostEnvironment environment) 
        {
            _environment = environment;
            _context = context;
        }

        public async Task<Social> Add(Social social , IFormFile file)
        {
            string wwwroot = _environment.WebRootPath;
            string? fileName = Path.GetFileNameWithoutExtension(file?.FileName);
            string extension = Path.GetExtension(file?.FileName);
            social.Icon = @"\Images\" + (fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension);
            string path = Path.Combine(wwwroot+"/Images/", fileName);
            if (social.Icon != null)
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await file?.CopyToAsync(fileStream);
                }
            }
            await _context.Socials.AddAsync(social);
            await _context.SaveChangesAsync();
            return social;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Social> GetAll()
        {
            throw new NotImplementedException();
        }

        public Social GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Social update(Social social)
        {
            throw new NotImplementedException();
        }
    }
}

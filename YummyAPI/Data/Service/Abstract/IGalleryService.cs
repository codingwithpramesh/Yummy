using YummyAPI.Models;

namespace YummyAPI.Data.Service.Abstract
{
    public interface IGalleryService
    {
        IEnumerable<Gallery> GetAll();

        Gallery GetById(int id);

        Task<Gallery> Add(Gallery gallery, IFormFile file);

        Task<Gallery> update(Gallery gallery);

        Task Delete(int id);
    }
}

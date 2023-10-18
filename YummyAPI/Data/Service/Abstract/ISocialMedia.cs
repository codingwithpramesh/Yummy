using YummyAPI.Models;

namespace YummyAPI.Data.Service.Abstract
{
    public interface ISocialMedia
    {
        IEnumerable<Social> GetAll();

        Social GetById(int id);

        Task<Social> Add(Social social , IFormFile file);

        Social update(Social social);

        void Delete(int id);
    }
}

using YummyAPI.Models;

namespace YummyAPI.Data.Service.Abstract
{
    public interface IEcomPortFolioService
    {

        IEnumerable<EcomPortfolio> GetAll();

        EcomPortfolio GetById(int id);

        Task<EcomPortfolio> AddAsync(EcomPortfolio ecom , IFormFile file);

        EcomPortfolio update(EcomPortfolio ecom);

        void Delete(int id);
    }
}

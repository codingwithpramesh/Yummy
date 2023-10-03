using YummyAPI.Models;

namespace YummyAPI.Data.Service.Abstract
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();

        Book GetById(int id);

        void Add(Book book);

        Book update(Book book);

        void Delete(int id);
    }
}

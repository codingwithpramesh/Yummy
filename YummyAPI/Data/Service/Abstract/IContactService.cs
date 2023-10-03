using YummyAPI.Models;

namespace YummyAPI.Data.Service.Abstract
{
    public interface IContactService
    {

        IEnumerable<Contact> GetAll();

        Contact GetById(int id);

        void Add(Contact contact);

        Contact update(Contact contact);

        void Delete(int id);
    }
}

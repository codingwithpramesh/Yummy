using YummyAPI.Models;

namespace YummyAPI.Data.Service.Abstract
{
    public interface IEventService
    {
        IEnumerable<Event> GetAll();

        Event GetById(int id);

        Task<Event> Add(Event events, IFormFile file);

        Task<Event> update(Event events);

        Task Delete(int id);
    }
}

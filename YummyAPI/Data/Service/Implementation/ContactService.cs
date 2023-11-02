using Microsoft.EntityFrameworkCore;
using YummyAPI.Data.Service.Abstract;
using YummyAPI.Models;

namespace YummyAPI.Data.Service.Implementation
{
    public class ContactService : IContactService
    {
        private readonly ApplicationDbContext _context;
        public ContactService(ApplicationDbContext context)
        {
            _context=context;
        }
        public void Add(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Contact data = _context.Contacts.Where(re => re.Id == id).FirstOrDefault();
            _context.Contacts.Remove(data);
            _context.SaveChanges();
        }

        public IEnumerable<Contact> GetAll()
        {
            IEnumerable<Contact> data = _context.Contacts.ToList();
            return data;
        }

        public Contact GetById(int id)
        {
            Contact data = _context.Contacts.FirstOrDefault(x => x.Id == id);
            return data;
        }

        public Contact update(Contact contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChanges(true);
            return contact;
        }
    }
}

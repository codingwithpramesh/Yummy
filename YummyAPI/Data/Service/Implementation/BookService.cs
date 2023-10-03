using YummyAPI.Data.Service.Abstract;
using YummyAPI.Models;

namespace YummyAPI.Data.Service.Implementation
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;
        public BookService(ApplicationDbContext context)
        {
            _context=context;
        }

        public void Add(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            Book data = _context.Books.Where(re => re.Id == id).FirstOrDefault();
            _context.Books.Remove(data);
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetAll()
        {
            IEnumerable<Book> data = _context.Books.ToList();
            return data;
        }

        public Book GetById(int id)
        {
            Book data = _context.Books.FirstOrDefault(x => x.Id == id);
            return data;
        }

        public Book update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges(true);
            return book;
        }
    }
}


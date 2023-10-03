using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using YummyAPI.Data;
using YummyAPI.Data.Enum;
using YummyAPI.Models;
using YummyAPI.Models.ViewModel;


namespace YummyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BookController( ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _context.Books.ToList();
            return Ok(data);
        }

        [HttpPost("Create")]
        public IActionResult Create(BOOKVM book)
        {
            var a = new Book
            {
                Name=   book.Name,
                email = book.email,
                Phone= book.Phone,
                Date = book.Date,
                TimeCategory = book.TimeCategory,
                TotalPeople = book.TotalPeople,
                Message = book.Message,
            };
            _context.Books.Add(a);
            _context.SaveChanges();
            return Ok(a);

        }

        [HttpPut("update")]
        public IActionResult update( int id, BOOKVM book)
        {
            var data = _context.Books.Find(id);
            if (data != null)
            {
                data.Name=   book.Name;
                data.email = book.email;
                data.Phone= book.Phone;
                data.Date = book.Date;
                data.TimeCategory = book.TimeCategory;
                data.TotalPeople = book.TotalPeople;
                data.Message = book.Message;
                _context.SaveChanges();
                return Ok(data);
            }
            return NotFound();
        }


        [HttpGet("Update")]
        public async Task<IActionResult> Update( int id)
        {
            var data = await _context.Books.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }


        [HttpGet("GetDelete")]
        public IActionResult GetDelete(int id)
        {
            var data = _context.Books.Find(id);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        [HttpDelete ("Delete")]
        public IActionResult Delete(int id)
        {
            var data = _context.Books.Find(id);
            if (data != null)
            {
                _context.Books.Remove(data);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }


        [HttpGet("Details")]
        public IActionResult Details( int id)
        {
            var user = _context.Books.Find(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

    }
}

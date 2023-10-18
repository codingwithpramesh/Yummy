using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyAPI.Data;
using YummyAPI.Models.ViewModel;
using YummyAPI.Models;
using System.Drawing;
using YummyAPI.Data.Service.Abstract;

namespace YummyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialController : ControllerBase
    {
        private readonly ISocialMedia _service;
        public SocialController( ISocialMedia service) 
        {
            _service = service;
        }



        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            //var data = _context.Socials.ToList();
            return Ok();
        }

        [HttpPost("Create")]
        public IActionResult Create(Social social , IFormFile file)
        {
            var data = _service.Add(social, file);
            return Ok(data);

        }

        [HttpPut("update")]
        public IActionResult update(int id, BOOKVM book)
        {
            /*var data = _context.Books.Find(id);
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
                return Ok(data);*/
            /*            }
                        return NotFound();*/
            return Ok();
        }


        [HttpGet("Update")]
        public async Task<IActionResult> Update(int id)
        {
            /*var data = await _context.Books.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);*/
            return Ok();
        }


        [HttpGet("GetDelete")]
        public IActionResult GetDelete(int id)
        {
            /* var data = _context.Books.Find(id);
             if (data != null)
             {
                 return Ok(data);
             }
             return NotFound();*/
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            /*var data = _context.Books.Find(id);
            if (data != null)
            {
                _context.Books.Remove(data);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();*/
            return Ok();
        }


        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            /* var user = _context.Books.Find(id);

             if (user == null)
             {
                 return NotFound();
             }
             return Ok(user);*/
            return Ok();
        }

    }


}

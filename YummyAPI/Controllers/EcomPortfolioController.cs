using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YummyAPI.Data.Service.Abstract;
using YummyAPI.Models.ViewModel;
using YummyAPI.Models;

namespace YummyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcomPortfolioController : ControllerBase
    {

        private readonly IEcomPortFolioService _service;
       
        public EcomPortfolioController(IEcomPortFolioService service )
        {
            _service = service;


        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            var data = _service.GetAll();
            return Ok(data);
        }

        [HttpPost("Create")]
        public IActionResult Create(EcomPortfolioVM ecom , IFormFile file)
        {
           /*var data = _service.Add(ecom, file);*/
           return Ok();

        }

        [HttpPut("Update")]
        public IActionResult Update(int id, ContactVM contactVm)
        {
            /*var data = _context.Contacts.Find(id);
            if (data != null)
            {
                data.Name = contactVm.Name;
                data.Email = contactVm.Email;
                data.Subject = contactVm.Subject;
                data.Message = contactVm.Message;
            }
            return NotFound();*/
            return Ok();
        }


        [HttpGet("Update")]
        public async Task<IActionResult> Update(int id)
        {
            /*var data = await _context.Contacts.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);*/
            return Ok();
        }


        [HttpDelete("Delete")]

        public IActionResult Delete(int id)
        {
            /*var data = _context.Contacts.Find(id);
            if (data != null)
            {
                _context.Contacts.Remove(data);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();*/
            return Ok();
        }


        [HttpGet("Details")]

        public IActionResult Details([FromRoute] int id)
        {
            /* var user = _context.Contacts.Find(id);

             if (user == null)
             {
                 return NotFound();
             }
             return Ok(user);*/
            return Ok();
        }


    }
}

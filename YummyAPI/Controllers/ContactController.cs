using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YummyAPI.Data;
using YummyAPI.Data.Service.Abstract;
using YummyAPI.Models;
using YummyAPI.Models.ViewModel;

namespace YummyAPI.Controllers
{
   /* [Authorize]*/
    public class ContactController : Controller
    {
        private readonly IContactService _service;
        private readonly ApplicationDbContext _context;
        public ContactController( IContactService service , ApplicationDbContext context) 
        {
           _service = service;
            _context = context;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            var data = _service.GetAll();
            return Ok(data);
        }


        [HttpPost("Create")]
        public IActionResult Create([FromBody]ContactVM contactVM)
        {
            var data = new Contact
            {
                Name=   contactVM.Name,
                Email = contactVM.Email,
                 Subject= contactVM.Subject,
                Message = contactVM.Message,
            };
            _context.Contacts.Add(data);
            _context.SaveChanges();
            return Ok(data);

        }

        [HttpPut("Update")]
        public IActionResult Update(int id , [FromBody]ContactVM contactVm)
        {
            var data = _context.Contacts.Find(id);
            if (data != null)
            {
                data.Name = contactVm.Name;
                data.Email = contactVm.Email;
                data.Subject = contactVm.Subject;
                data.Message = contactVm.Message;
                _context.Contacts.Update(data);
                _context.SaveChanges();
                return Ok(data);
            }
            return NotFound();
        }


        [HttpGet("Update")]
        public async Task<IActionResult> Update(int id)
        {
            var data = await _context.Contacts.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }


        [HttpDelete("Delete")]

        public IActionResult Delete(int id)
        {
            var data = _context.Contacts.Find(id);
            if (data != null)
            {
                _context.Contacts.Remove(data);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }


        [HttpGet("Details")]
        public IActionResult Details( int id)
        {
            var user = _context.Contacts.Find(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}

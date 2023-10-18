using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using YummyAPI.Data.Service.Abstract;
using YummyAPI.Models;

namespace YummyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _service;
        public EventController( IEventService Service)
        {
            _service = Service;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            var data = _service.GetAll();
            return Ok(data);
        }

        [HttpPost("Create")]
        public IActionResult Create(Event events , IFormFile? file)
        {
            var data = _service.Add(events , file );
            return Ok(data);
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int id) 
        {
            var data = _service.Delete(id);
            return Ok();
        }
    }
}

using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using YummyAPI.Data.Service.Abstract;
using YummyAPI.Models;
using YummyAPI.Models.DTO;
using YummyAPI.Models.ViewModel;
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
        public async Task<IActionResult> Create([FromForm] Event events, IFormFile file)
        {

            var data =  await _service.Add(events, file );
            return Ok(data);
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int id) 
        {
            var data = _service.GetById(id);
            return Ok(data);
        }

        [HttpDelete("Delete")]
        public IActionResult Deleted(int id)
        {
            var data = _service.Delete(id);
            return Ok();
        }
        [HttpPut("update")]
        public async Task<IActionResult> update([FromForm] Event events )
        {
            var data = await _service.update(events);
            return Ok(data);
        }


        [HttpGet("Update")]
        public async Task<IActionResult> Update(int id)
        {
            var data = _service.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

    }
}

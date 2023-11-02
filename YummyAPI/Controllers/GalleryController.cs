using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YummyAPI.Data.Service.Abstract;
using YummyAPI.Models;
namespace YummyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
       
        private readonly IGalleryService _Service;
        public GalleryController( IGalleryService service)
        {
            _Service = service;
           
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            var data = _Service.GetAll();
            return Ok(data);
        }
        [HttpPost("Create")]
        public IActionResult Create([FromForm]Gallery gallary, IFormFile file)
        {
            var data = _Service.Add(gallary, file);
            return Ok(data);
        }

        [HttpPut("Update")]
        public IActionResult Update(Gallery gallery)
        {
            var data = _Service.update(gallery);
            return Ok(data);
        }

        [HttpGet("Details")]
        public IActionResult Details (int id)
        {
            var data = _Service.GetById(id);
            return Ok(data);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var data = _Service.Delete(id);
            return Ok(data);
        }
    }
}

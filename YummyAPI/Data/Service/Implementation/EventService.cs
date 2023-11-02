using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Win32;
using System.Collections;
using System.Numerics;
using System.Web.Http.ModelBinding;
using System.Web.Mvc;
using YummyAPI.Data.Service.Abstract;
using YummyAPI.Models;
namespace YummyAPI.Data.Service.Implementation
{
    [Authorize]
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public EventService(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _environment = environment;
            _context = context;
        }
        public IEnumerable<Event> GetAll()
        {
            var data = _context.Events.ToList();
            return data;
        }

        public Event GetById(int id)
        {
            var data = _context.Events.FirstOrDefault(e => e.Id == id);
            return data;
        }
        public async Task<Event> update(Event  events)
        {
            try
            {
                var data = _context.Events.FirstOrDefault(x => x.Id == events.Id);
                if (data != null)
                {
                    string wwwroot = _environment.WebRootPath;
                    if (data.EventImage != null)
                    {
                        string filepath = Path.Combine(wwwroot+ data.EventImage);
                        File.Delete(filepath);
                    }
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(events.ImageEvent.FileName);
                    string extension = Path.GetExtension(events.ImageEvent.FileName);
                    string newFileName = fileNameWithoutExtension + DateTime.Now.ToString("yymmssfff") + extension;
                    string newPath = Path.Combine(wwwroot+"/Images/", newFileName);
                    using (var fileStream = new FileStream(newPath, FileMode.Create))
                    {
                        await events.ImageEvent.CopyToAsync(fileStream);
                    }
                    events.EventImage = @"\Images\" + newFileName;
                    _context.Events.Update(events);
                    await _context.SaveChangesAsync();
                    return events;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());   
            }

            return null;
        }

        public async Task<Event> Add(Event events, IFormFile file)
        {
            try
            {
                string wwwRootPath = _environment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(events.ImageEvent.FileName);
                string extension = Path.GetExtension(events.ImageEvent.FileName);
                events.EventImage = @"\Images\" + (fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension);
                string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await events.ImageEvent.CopyToAsync(fileStream);
                }
                await _context.AddAsync(events);
                await _context.SaveChangesAsync();
                return events;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        public async Task Delete(int id)
        {
            

            var data = _context.Events.FirstOrDefault(x => x.Id == id);
            if (data == null)
            {
                throw new ArgumentException($"No event found with ID {id}");
            }
            if (!string.IsNullOrEmpty(data.EventImage))
            {
                string wwwroot = _environment.WebRootPath;
                string filepath = Path.Combine(wwwroot, "Images", data.EventImage);

                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
            }
            _context.Events.Remove(data);
            await _context.SaveChangesAsync();
        }
    }
}

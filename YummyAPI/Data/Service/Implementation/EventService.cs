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
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public EventService(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _environment = environment;
            _context = context;
        }

        public IEnumerable<Event> Index()
        {
            IEnumerable<Event> data = _context.Events.ToList();
            return data;
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
        /*public async Task<Event> AddAsync(Event events, List<IFormFile> files)
        {
            try
            {
                if (files != null && files.Count > 0)
                {
                    string wwwroot = Path.Combine(_environment.WebRootPath, "Images");
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            var filePath = Path.Combine(wwwroot, Path.GetRandomFileName() + Path.GetExtension(file.FileName));
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }
                        }
                    }
                }
                await _context.Events.AddAsync(events);
                await _context.SaveChangesAsync();
                return events;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }*/

        public Event update(Event events)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Event> Add(Event events, IFormFile? file )
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

        public async Task Delete (int id)
        {
            var data = _context.Events.FirstOrDefault(x => x.Id == id);

            if(data.EventImage != null)
            {
                
                string wwwroot = _environment.WebRootPath;
                string filepath = Path.Combine(wwwroot, "Images" + data.ImageEvent.FileName);

                if(File.Exists(filepath))
                {
                    File.Delete(data.ImageEvent.FileName);
                }

            }
           _context.Events.Remove(data);
            await _context.SaveChangesAsync();
            
        }
    }
}

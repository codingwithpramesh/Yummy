using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YummyM.Models
{
    public class EventVM
    {
        [Key]
        public int Id { get; set; }
        public string? eventtitle { get; set; }
        public string? eventDescription { get; set; }
        public string? EventImage { get; set; }
        [NotMapped]
        public List<IFormFile>? ImageEvent { get; set; }
        public decimal? EventPrice { get; set; }
        public string? eventDescrip { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YummyAPI.Models.ViewModel
{
    public class GalleryVM
    {
        [Key]
        public int Id { get; set; }

        public string? GalleryTitle { get; set; }

        public string? GalleryImage { get; set; }

        [NotMapped]
        public IFormFile? ImageGallery { get; set; }
    }
}

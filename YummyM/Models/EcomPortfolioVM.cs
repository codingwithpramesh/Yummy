using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YummyM.Data;
namespace YummyM.Models
{
    public class EcomPortfolioVM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? HeroTitle { get; set; }

        public string? HeroDescription { get; set; }

        public string? HeroButton { get; set; }

        public string? AboutTitle { get; set; }

        public string? AboutDescription { get; set; }

        public string? AboutImage { get; set; }

        [NotMapped]
        public IFormFile? ImageAbout { get; set; }

        public string? AboutNumber { get; set; }

        public string? AboutVideos { get; set; }

        [NotMapped]
        public IFormFile? VideosAbout { get; set; }

        public string? CardTitle { get; set; }

        public string? CardDescription { get; set; }

        public string? CardButtonText { get; set; }

        public string? TotalClient { get; set; }

        public string? totalProject { get; set; }

        public string? TotalHours { get; set; }

        public string? TotalWorkers { get; set; }

        public string? MenuTitle { get; set; }

        public string? Menuvalue { get; set; }

        public Time? TimeCategory { get; set; }

        public string? professorTitle { get; set; }

        public string? ProfessorDescription { get; set; }

        public string? professorName { get; set; }

        public string? ProfessorPosition { get; set; }

        public string? ProfessorRating { get; set; }

        public string? eventtitle { get; set; }

        public string? eventDescription { get; set; }


        public string? EventImage { get; set; }

        [NotMapped]
        public List<IFormFile>? ImageEvent { get; set; }

        public string? EventPrice { get; set; }

        public string? eventDescrip { get; set; }

        public string? chefTitle { get; set; }


        public string? ChefImage { get; set; }

        [NotMapped]
        public IFormFile? Imagechef { get; set; }

        public string? chefName { get; set; }

        public string? ChefPosition { get; set; }

        public string? ChefDescription { get; set; }

        public string? GalleryTitle { get; set; }

        public string? GalleryImage { get; set; }

        [NotMapped]
        public List<IFormFile>? ImageGallery { get; set; }

        public string? ContactTitle { get; set; }

        public string? ContactDescription { get; set; }

        public string? contactEmail { get; set; }

        public string? contactAddress { get; set; }

        public string? Phone { get; set; }

        public string? OpeningHour { get; set; }


        public string? FooterAddress { get; set; }

        public string? FooterPhone { get; set; }

        public string? FooterEmail { get; set; }

        public string? FooterOpeningHour { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;
using YummyAPI.Data.Enum;
namespace YummyAPI.Models
{
    public class EcomPortfolio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
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

        public int? TotalClient { get; set; }

        public int? totalProject { get; set; }

        public int? TotalHours { get; set; }

        public int? TotalWorkers { get; set; }

        public string? MenuTitle { get; set; }

        public string? Menuvalue { get; set; }

        public Time?  TimeCategory { get; set; }

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

        public decimal? EventPrice { get; set; }

        public string? eventDescrip { get; set; }

        public string? chefTitle { get; set; }
        public string? ChefImage { get; set; }
        [NotMapped]
        public IFormFile? Imagechef { get; set; }
        public string? chefName { get; set; }
        public string? ChefPosition { get; set; }
        public string? ChefDescription { get; set; }
        public string? ContactTitle { get; set; }
        public string? ContactDescription { get; set; }
        public string? contactEmail { get; set; }
        public string? contactAddress { get; set; }
        public string? Phone { get; set; }
        public int? OpeningHour { get; set; }
        public string? FooterAddress { get; set; }
        public string? FooterPhone { get; set; }
        public string? FooterEmail { get; set; }
        public string? FooterOpeningHour { get; set; }
    }
}

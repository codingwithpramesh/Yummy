using System.ComponentModel.DataAnnotations.Schema;

namespace YummyAPI.Models.ViewModel
{
    public class SocialVM
    {
        public string Icon { get; set; }

        [NotMapped]
        public IFormFile? IconFile { get; set; }

        public string Link { get; set; }

        public int EId { get; set; }
        [ForeignKey("EId")]
        public EcomPortfolio? Portfolio { get; set; }
    }
}

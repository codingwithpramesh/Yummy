using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YummyAPI.Models
{
    public class Social
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        public string? Icon { get; set; }

        [NotMapped]
        public IFormFile? IconFile { get; set; }

        public string Link { get; set; }

       /* public int EId { get; set; }
        [ForeignKey("EId")]
        public EcomPortfolio? Portfolio { get; set; }*/
    }
}

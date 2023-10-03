using System.ComponentModel.DataAnnotations;

namespace YummyM.Models
{
    public class ContactVM
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}

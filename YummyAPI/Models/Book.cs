using System.ComponentModel.DataAnnotations;

namespace YummyAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string  email { get; set; }

        public string Phone { get; set; }

        public DateTime Date { get; set; }

        public DateTime TimeCategory { get; set; }

        public int TotalPeople { get; set; }

        public string Message { get; set; }
    }
}

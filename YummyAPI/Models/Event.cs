﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YummyAPI.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string? eventtitle { get; set; }
        public string? eventDescription { get; set; }
        public string? EventImage { get; set; }
        [NotMapped]
        public IFormFile? ImageEvent { get; set; }
        public decimal? EventPrice { get; set; }
        public string? eventDescrip { get; set; }
    }
}

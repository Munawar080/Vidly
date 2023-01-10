using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models.CustomValidation;

namespace Vidly.Models.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        //[MovieNameMinAndMaxLength]
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }
        public byte GenreId { get; set; }

        public GenreDTO Genre { get; set; }

        [Required]
        [Range(1, 20)]
        public int stock { get; set; }

        public byte? NumberAvailable { get; set; }
    }
}
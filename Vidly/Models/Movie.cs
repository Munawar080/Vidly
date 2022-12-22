using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vidly.Models.CustomValidation;
namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
         //[MovieNameMinAndMaxLength]
        public string Name { get; set; }
        
        
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate{ get; set; }

        public DateTime? DateAdded{ get; set; }

        
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        public Genre Genre { get; set; }
        
        [Required]
        [Range(1, 20)]
        [Display(Name = "Number in stock")]
        public int stock { get; set; }

        public byte? NumberAvailable{ get; set; }
    }
}
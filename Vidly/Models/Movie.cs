using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

       
        [Display(Name="Movie Name")]
        public string Name { get; set; }
    }
}
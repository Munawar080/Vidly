using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        // add additional fields for security reasons
        [Required]
        [StringLength(255)]
        public string Email { get; set; }

       
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
    }
}
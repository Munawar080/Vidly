using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id{ get; set; }

        [Required]
        [StringLength(255)]
        public string Name{ get; set; }

        [Display(Name="Date of Birth")]
        [Min18YearsIFAMember]
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }


        // entity framework recognize this as a convention and treat this prop as a foreign key.

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId{ get; set; }
        public MembershipType MembershipType{ get; set; }
    }
}
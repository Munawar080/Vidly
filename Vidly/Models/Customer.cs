using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id{ get; set; }

        [Required]
        [StringLength(255)]
        public string Name{ get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MyProperty { get; set; }


        // entity framework recognize this as a convention and treat this prop as a foreign key.
        public byte MembershipTypeId{ get; set; }
    }
}
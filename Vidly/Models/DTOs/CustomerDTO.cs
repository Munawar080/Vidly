using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models.DTOs
{
    public class CustomerDTO
    {
        public int Id{ get; set; }

        [Required(ErrorMessage="Name is required")]
        [StringLength(255)]
        public string Name{ get; set; }
        
        //[Min18YearsIFAMember]
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        
        // entity framework recognize this as a convention and treat this prop as a foreign key.
        public byte MembershipTypeId{ get; set; }
    
    }
}
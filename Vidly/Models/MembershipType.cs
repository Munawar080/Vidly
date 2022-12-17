﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate{ get; set; }
        public short SignUpFree{ get; set; }

        [Required]
        public string Name{ get; set; }
    }
}
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RentalCRM.Models
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public int UserId { get; set; }
        public int AdminId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime CreatedTime { get; set; }
        public int Active { get; set; }
    }
}

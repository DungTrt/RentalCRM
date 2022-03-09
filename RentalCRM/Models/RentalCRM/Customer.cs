using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RentalCRM.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public int CateId { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string CitizenId { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int? Active { get; set; }
        public string Photo { get; set; }
        public int? BranchId { get; set; }
    }
}

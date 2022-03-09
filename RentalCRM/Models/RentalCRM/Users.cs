using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RentalCRM.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
        public int WardId { get; set; }
        public string Address { get; set; }
        public string Fullname { get; set; }
        public int Active { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string CateId { get; set; }
        public int? BranchId { get; set; }
    }
}

using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RentalCRM.Models
{
    public partial class CashReport
    {
        public int CashReportId { get; set; }
        public DateTime CreatedTime { get; set; }
        public int UserId { get; set; }
        public int Amount { get; set; }
        public int TypeId { get; set; }
        public string Description { get; set; }
        public int OrderId { get; set; }
        public int BranchId { get; set; }
    }
}

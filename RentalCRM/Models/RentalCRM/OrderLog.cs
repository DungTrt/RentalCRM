using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RentalCRM.Models
{
    public partial class OrderLog
    {
        public int OrderLogId { get; set; }
        public int TypeId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int CreatedStaffId { get; set; }
        public int? UpdatedStaffId { get; set; }
        public int CustomerId { get; set; }
        public int BranchId { get; set; }
        public string PromotionCode { get; set; }
        public int? DirectDiscount { get; set; }
        public string Description { get; set; }
        public int? StatusId { get; set; }
        public int? Price { get; set; }
        public int? AdvancePayment { get; set; }
        public int? TotalPaid { get; set; }
        public DateTime? ExpectedReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int? FinalPrice { get; set; }
        public int OrderId { get; set; }
    }
}

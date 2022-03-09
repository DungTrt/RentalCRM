using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RentalCRM.Models
{
    public partial class Promotion
    {
        public int PromotionId { get; set; }
        public string PromotionName { get; set; }
        public int? Active { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string Code { get; set; }
        public int? UsedTime { get; set; }
        public int? BranchId { get; set; }
        public int? ProductCateId { get; set; }
        public int? CustomerCateId { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

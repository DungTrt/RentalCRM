using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RentalCRM.Models
{
    public partial class ProductItemLog
    {
        public int ProductItemLogId { get; set; }
        public int ProductItemId { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int Quantity { get; set; }
        public int? Availability { get; set; }
        public string Description { get; set; }
        public int? Active { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? UpdatedStaffId { get; set; }
    }
}

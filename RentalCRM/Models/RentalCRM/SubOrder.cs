using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RentalCRM.Models
{
    public partial class SubOrder
    {
        public int SubOrderId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public int StatusId { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int? Active { get; set; }
        public int ProductItemId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}

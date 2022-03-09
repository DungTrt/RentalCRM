using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RentalCRM.Models
{
    public partial class ProductPrice
    {
        public int ProductPriceId { get; set; }
        public int ProductId { get; set; }
        public int CustomerCateId { get; set; }
        public int BranchId { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int? Active { get; set; }
    }
}

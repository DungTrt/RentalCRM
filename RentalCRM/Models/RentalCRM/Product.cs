using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RentalCRM.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public int CateId { get; set; }
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Active { get; set; }
        public string Photo { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int? Quantity { get; set; }
        public int? Availability { get; set; }
        public string Location { get; set; }
        public int? BasePrice { get; set; }
        public int? BuyPrice { get; set; }
        public int? SellPrice { get; set; }
        public string CodeName { get; set; }
        public int UnitId { get; set; }
    }
}

using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RentalCRM.Models
{
    public partial class Counter
    {
        public int CounterId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int ViewCount { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Active { get; set; }
    }
}

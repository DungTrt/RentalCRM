using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RentalCRM.Models
{
    public partial class Menu
    {
        public int MenuId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public int? Priority { get; set; }
        public int Active { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int ParentId { get; set; }
    }
}

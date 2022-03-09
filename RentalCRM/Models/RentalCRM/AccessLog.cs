using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RentalCRM.Models
{
    public partial class AccessLog
    {
        public int AccessLogId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Ip { get; set; }
        public string Device { get; set; }
        public string Os { get; set; }
        public string Browser { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string CurrentUrl { get; set; }
    }
}

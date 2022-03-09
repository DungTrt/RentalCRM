using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RentalCRM.Models
{
    public partial class Disaster
    {
        public int DisasterId { get; set; }
        public int CateId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
        public int Danger { get; set; }
        public int Scope { get; set; }
        public int WardId { get; set; }
        public string Location { get; set; }
        public int SenderId { get; set; }
        public int AdminId { get; set; }
        public int Approve { get; set; }
        public int Active { get; set; }
        public DateTime SentTime { get; set; }
        public DateTime ApproveTime { get; set; }
        public string Photo { get; set; }
        public int? Emergency { get; set; }
        public string PhotoOrg { get; set; }
    }
}

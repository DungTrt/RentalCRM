using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RentalCRM.Models
{
    public partial class Survey
    {
        public int SurveyId { get; set; }
        public int CateId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string Photo { get; set; }
        public DateTime CreatedTime { get; set; }
        public int Active { get; set; }
        public int AdminId { get; set; }
        public string PhotoOrg { get; set; }
    }
}

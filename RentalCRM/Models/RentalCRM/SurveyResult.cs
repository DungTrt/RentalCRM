using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RentalCRM.Models
{
    public partial class SurveyResult
    {
        public int SurveyResultId { get; set; }
        public int SurveyId { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string Text { get; set; }
        public int Active { get; set; }
    }
}

using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RentalCRM.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int TypeId { get; set; }
        public int ArticleId { get; set; }
        public string Text { get; set; }
        public int Approve { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int UserId { get; set; }
    }
}

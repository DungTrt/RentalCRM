using System;

namespace RentalCRM.ViewModel
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public int CateId { get; set; }
        public string CateName { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string CitizenId { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int? Active { get; set; }
        public string  StatusName { get; set; }
        public string Photo { get; set; }
        public int? BranchId { get; set; }
        public string BranchName { get; set; }
    }
}

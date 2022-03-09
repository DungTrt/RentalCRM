namespace RentalCRM.ViewModel
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int WardId { get; set; }
        public string Address { get; set; }
        public string Fullname { get; set; }
        public int Active { get; set; }
        public string StatusName { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string CateId { get; set; }
        public int? BranchId { get; set; }
        public string BranchName { get; set; }
    }
}

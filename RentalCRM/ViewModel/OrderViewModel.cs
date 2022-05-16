using System;

namespace RentalCRM.ViewModel
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int TypeId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int CreatedStaffId { get; set; }
        public int? UpdatedStaffId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerCategoryId { get; set; }
        public string CustomerCategoryName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductSizeId { get; set; }
        public string ProductSizeName { get; set; }
        public string PromotionCode { get; set; }
        public int? DirectDiscount { get; set; }
        public string Description { get; set; }
        public int? StatusId { get; set; }
        public long? Price { get; set; }
        public long? AdvancePayment { get; set; }
        public long? TotalPaid { get; set; }
        public DateTime? ExpectedReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public long? FinalPrice { get; set; }
        public string DepositInfo { get; set; }
        public int? IsEdited { get; set; }
        public int Quantity { get; set; }
    }
}

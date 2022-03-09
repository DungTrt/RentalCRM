using RentalCRM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCRM.Repository
{
    public interface IOrderRepository
    {
        Task<List<OrderViewModel>> RecentOrder();
        int Count();
        Task<List<ReportByCustomerViewModel>> ReportByCustomer(DateTime startDate,DateTime endDate);
        Task<List<ReportByProductViewModel>> ReportByProduct(DateTime startDate, DateTime endDate);
        Task<List<ReportByCustomerCategoryViewModel>> ReportByCustomerCategory(DateTime startDate, DateTime endDate);
        Task<List<ReportByProductCategoryViewModel>> ReportByProductCategory(DateTime startDate, DateTime endDate);
        Task<List<ReportRevenueByTimeViewModel>> ReportRevenueByTime(DateTime startDate, DateTime endDate);
        Task<List<ReportRevenueByBranchViewModel>> ReportRevenueByBranch(DateTime startDate, DateTime endDate);
    }
}

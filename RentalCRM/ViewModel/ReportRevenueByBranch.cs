using System;
using System.Collections.Generic;
using System.Linq;
namespace RentalCRM.ViewModel
{
    public class ReportRevenueByBranchViewModel
    {
        public string BranchName { get; set; }
        public List<BranchChartData> DataSource { set; get; }
    }
    public class BranchChartData
    {
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public int TotalMoney { get; set; }
    }
}

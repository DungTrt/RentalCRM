using RentalCRM.Models;
using RentalCRM.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace RentalCRM.Repository.RentalCRM
{

    public class OrderRepository : IOrderRepository
    {
        private readonly RentalCRMContext db;
        public OrderRepository(RentalCRMContext _db)
        {
            db = _db;
        }

        public int Count()
        {
            return db.Orders.Count();
        }

        public async Task<List<OrderViewModel>> RecentOrder()
        {
            return await (from order in db.Orders
                          from customer in db.Customer
                          from customerCategory in db.CustomerCategory
                          from orderDetail in db.OrderDetail
                          from product in db.Product
                          from productItem in db.ProductItem
                          from productSize in db.ProductSize
                          from branch in db.Branch
                          where order.CustomerId == customer.CustomerId && order.OrderId == orderDetail.OrderId && orderDetail.ProductItemId == productItem.ProductItemId && product.ProductId == productItem.ProductItemId && order.BranchId == branch.BranchId && customer.CateId == customerCategory.CateId
                          orderby order.CreatedTime descending
                          select new OrderViewModel
                          {
                              AdvancePayment = order.AdvancePayment,
                              BranchId = order.BranchId,
                              BranchName = branch.BranchName,
                              CreatedTime = order.CreatedTime,
                              CreatedStaffId = order.CreatedStaffId,
                              CustomerCategoryId = customer.CateId,
                              CustomerCategoryName = customerCategory.CateName,
                              CustomerId = order.CustomerId,
                              CustomerName = customer.Fullname,
                              DepositInfo = order.DepositInfo,
                              Description = order.Description,
                              DirectDiscount = order.DirectDiscount,
                              ExpectedReturnDate = order.ExpectedReturnDate,
                              FinalPrice = order.FinalPrice,
                              IsEdited = order.IsEdited,
                              OrderId = order.OrderId,
                              Price = order.Price,
                              ProductId = product.ProductId,
                              ProductName = product.Name,
                              ProductSizeName = productSize.SizeName,
                              ProductSizeId = productSize.SizeId,
                              PromotionCode = order.PromotionCode,
                              ReturnDate = order.ReturnDate,
                              StatusId = order.StatusId,
                              TotalPaid = order.TotalPaid,
                              TypeId = order.TypeId,
                              UpdatedStaffId = order.UpdatedStaffId,
                              Quantity = orderDetail.Quantity

                          })
            .Take(10)
            .ToListAsync();
        }

        public async Task<List<ReportByCustomerViewModel>> ReportByCustomer(DateTime startDate, DateTime endDate)
        {
            var report = db.Orders.AsEnumerable()
                .Where(o => o.ReturnDate >= startDate && o.ReturnDate <= endDate)
                .GroupBy(o => o.CustomerId)
                .Join(db.Customer, rp => rp.Key, customer => customer.CustomerId, (rp, customer) => new ReportByCustomerViewModel
                {
                    CustomerId = rp.Key,
                    TotalMoney = (int)rp.Sum(s => s.FinalPrice),
                    CustomerName = customer.Fullname
                })
                .OrderByDescending(o => o.TotalMoney)
                .Take(20);
            return report.ToList();
        }

        public async Task<List<ReportByCustomerCategoryViewModel>> ReportByCustomerCategory(DateTime startDate, DateTime endDate)
        {
            var data = (from order in db.Orders
                        from customer in db.Customer
                        from customerCategory in db.CustomerCategory
                        where order.ReturnDate >= startDate && order.ReturnDate <= endDate && order.CustomerId == customer.CustomerId && customer.CateId == customerCategory.CateId
                        select new
                        {
                            customerCategoryName = customerCategory.CateName,
                            FinalPrice = order.FinalPrice,
                        })
                        .GroupBy(o => o.customerCategoryName)
                        .Select(n => new ReportByCustomerCategoryViewModel
                        {
                            CustomerCategoryName = n.Key,
                            TotalMoney = (int)n.Sum(s => s.FinalPrice)
                        });
            return data.ToList();
        }

        public async Task<List<ReportByProductViewModel>> ReportByProduct(DateTime startDate, DateTime endDate)
        {
            //var report = db.Orders.AsEnumerable()
            //    .Where(o => o.ReturnDate >= startDate && o.ReturnDate <= endDate)
            //    .Join(db.Product, rp => rp.Key, product => product.ProductId, (rp, customer) => new ReportByCustomerViewModel
            //    {
            //        CustomerId = rp.Key,
            //        TotalMoney = (int)rp.Sum(s => s.FinalPrice),
            //        CustomerName = customer.Fullname
            //    })
            //    .OrderByDescending(o => o.TotalMoney)
            //    .Take(20);
            //return report.ToList();
            var data = (from order in db.Orders
                        from orderDetail in db.OrderDetail
                        from product in db.Product
                        where order.ReturnDate >= startDate && order.ReturnDate <= endDate && order.OrderId == orderDetail.OrderId && orderDetail.ProductItemId == product.ProductId
                        select new
                        {
                            orderId = order.OrderId,
                            FinalPrice = order.FinalPrice,
                            productId = product.ProductId,
                            productName = product.Name
                        })
                      .GroupBy(o => o.productName)
                      .Select(n => new ReportByProductViewModel
                      {
                          ProductName = n.Key,
                          TotalMoney = (int)n.Sum(s => s.FinalPrice)
                      })
                      .OrderByDescending(o => o.TotalMoney)
                      .Take(20);
            return data.ToList();
        }

        public async Task<List<ReportByProductCategoryViewModel>> ReportByProductCategory(DateTime startDate, DateTime endDate)
        {
            var data = (from order in db.Orders
                        from orderDetail in db.OrderDetail
                        from product in db.Product
                        from productCategory in db.ProductCategory
                        where order.ReturnDate >= startDate && order.ReturnDate <= endDate && order.OrderId == orderDetail.OrderId && orderDetail.ProductItemId == product.ProductId && product.CateId == productCategory.CateId
                        select new
                        {
                            FinalPrice = order.FinalPrice,
                            ProductCategoryId = productCategory.CateId,
                            ProductCategoryName = productCategory.CateName
                        })
                      .GroupBy(o => o.ProductCategoryName)
                      .Select(n => new ReportByProductCategoryViewModel
                      {
                          ProductCategoryName = n.Key,
                          TotalMoney = (int)n.Sum(s => s.FinalPrice)
                      })
                      .OrderByDescending(o => o.TotalMoney)
                      .Take(5);
            return data.ToList();
        }

        public async Task<List<ReportRevenueByBranchViewModel>> ReportRevenueByBranch(DateTime startDate, DateTime endDate)
        {
            var data = (from order in db.Orders.AsEnumerable()
                        from branch in db.Branch
                        where order.BranchId == branch.BranchId && order.ReturnDate >= startDate && order.ReturnDate <= endDate
                        select new OrderViewModel
                        {
                            FinalPrice = order.FinalPrice,
                            BranchId = branch.BranchId,
                            BranchName = branch.BranchName,
                            ReturnDate = order.ReturnDate
                        })
                     .GroupBy(o => o.BranchName)
                     .Select(n => new ReportRevenueByBranchViewModel
                     {
                         BranchName = n.Key,
                         DataSource = n.GroupBy(n => n.ReturnDate).Select(nn => new BranchChartData
                         {
                             Category = nn.Key.Value.ToString("dd/MM"),
                             Date = nn.Key.Value,
                             TotalMoney = (int)nn.Sum(s => s.FinalPrice)
                         }).ToList()

                     })
                     .ToList();
            //.ToList();
            //            .GroupBy(o => o.BranchName)
            //            .Select(n => new
            //            {
            //                BranchName = n.Key,
            //                DataSource = n.Select(nn => new
            //                {
            //                    ReturnDate = nn.ReturnDate,
            //                    TotalMoney = nn.
            //                })
            //            });


            while (startDate <= endDate)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    var obj = data[i].DataSource.FirstOrDefault(d => d.Category == startDate.ToString("dd/MM"));
                    if (obj == null)
                    {
                        data[i].DataSource.Add(new BranchChartData
                        {
                            Category = startDate.ToString("dd/MM"),
                            Date = startDate,
                            TotalMoney = 0
                        });
                        data[i].DataSource = data[i].DataSource.OrderBy(d => d.Date).ToList();
                    }

                }
                startDate = startDate.AddDays(1);

            };
            return data;
        }

        public async Task<List<ReportRevenueByTimeViewModel>> ReportRevenueByTime(DateTime startDate, DateTime endDate)
        {
            var data = db.Orders
                 .Where(o => o.ReturnDate >= startDate && o.ReturnDate <= endDate)
                 .AsEnumerable()
                 .GroupBy(o => o.ReturnDate.Value)
                 .OrderBy(o => o.Key)
                 .Select(n => new ReportRevenueByTimeViewModel
                 {
                     CategoryName = n.Key.ToString("dd/MM"),
                     Date = n.Key,
                     TotalMoney = (int)n.Sum(s => s.FinalPrice)
                 })
                 .ToList();
            while (startDate <= endDate)
            {
                var item = data.FirstOrDefault(d => d.CategoryName == startDate.ToString("dd/MM"));
                if (item == null)
                {
                    data.Add(new ReportRevenueByTimeViewModel
                    {
                        CategoryName = startDate.ToString("dd/MM"),
                        Date = startDate,
                        TotalMoney = 0
                    });
                }
                startDate = startDate.AddDays(1);
            }
            return data = data.OrderBy(d => d.Date).ToList();
        }
    }
}

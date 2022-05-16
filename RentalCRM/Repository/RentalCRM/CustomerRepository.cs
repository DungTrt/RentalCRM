using RentalCRM.Models;
using RentalCRM.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RentalCRM.Util;

namespace RentalCRM.Repository.RentalCRM
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly RentalCRMContext db;
        public CustomerRepository(RentalCRMContext _db)
        {
            db = _db;
        }
        public async Task<Customer> Add(Customer model)
        {
            if (db != null)
            {
                await db.Customer.AddAsync(model);
                await db.SaveChangesAsync();
                return model;
            }
            return null;
        }

        public int Count()
        {
            return (from customer in db.Customer
                    from cate in db.CustomerCategory
                    from branch in db.Branch
                    where customer.Active == 1 && customer.CateId == cate.CateId
                    && cate.Active == 1 && customer.BranchId == branch.BranchId && branch.Active == 1
                    select customer)
                   .Count();

        }

        public async Task Delete(Customer model)
        {
            if (db != null)
            {
                db.Customer.Attach(model);
                db.Entry(model).Property(x => x.Active).IsModified = true;

                await db.SaveChangesAsync();
            }
        }

        public Task<int> DeletePermanently(int customerId)
        {
            throw new System.NotImplementedException();
        }

        public Task<CustomerViewModel> GetByCustomerId(int customerId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<CustomerViewModel>> List()
        {
            return await (from customer in db.Customer
                          from cate in db.CustomerCategory
                          from branch in db.Branch
                          where customer.CateId == cate.CateId && customer.BranchId == branch.BranchId
                          select new CustomerViewModel
                          {
                              Active = customer.Active,
                              Address = customer.Address,
                              BranchId = customer.BranchId,
                              BranchName = branch.BranchName,
                              CateId = customer.CateId,
                              CateName = cate.CateName,
                              CitizenId = customer.CitizenId,
                              CreatedTime = customer.CreatedTime,
                              CustomerId = customer.CustomerId,
                              Description = customer.Description,
                              Email = customer.Email,
                              Fullname = customer.Fullname,
                              Phone = customer.Phone,
                              Photo = customer.Photo,
                              StatusName = customer.Active == 1 ? "Còn hiệu lực" : "Không còn hiệu lực"
                          }).ToListAsync();
        }

        public async Task<List<CustomerCategory>> ListCustomerCategory()
        {
            return await db.CustomerCategory.Where(c => c.Active == 1).ToListAsync();
        }

        public async Task Update(Customer model)
        {
            if (db != null)
            {
                db.Customer.Attach(model);
                db.Entry(model).Property(x => x.Fullname).IsModified = true;
                db.Entry(model).Property(x => x.CateId).IsModified = true;
                db.Entry(model).Property(x => x.BranchId).IsModified = true;
                db.Entry(model).Property(x => x.Address).IsModified = true;
                db.Entry(model).Property(x => x.CitizenId).IsModified = true;
                db.Entry(model).Property(x => x.Description).IsModified = true;
                db.Entry(model).Property(x => x.Email).IsModified = true;
                db.Entry(model).Property(x => x.Phone).IsModified = true;
                db.Entry(model).Property(x => x.Photo).IsModified = true;

                await db.SaveChangesAsync();
            }
        }

        public async Task<List<CustomerViewModel>> ListPaging(string sortType, string column,
            string customerId, string customerName, int? categoryId, int? branchId, string phone, string keyword)
        {
            List<CustomerViewModel> data = new List<CustomerViewModel>();
            if (string.IsNullOrEmpty(keyword))
            {
                data = await (from customer in db.Customer
                              from cate in db.CustomerCategory
                              from branch in db.Branch
                              where customer.Active == 1 && customer.CateId == cate.CateId && cate.Active == 1
                              && customer.BranchId == branch.BranchId && branch.Active == 1
                              && (string.IsNullOrEmpty(customerId) || customer.CustomerId.ToString().Contains(customerId))
                              && (string.IsNullOrEmpty(customerName) || customer.Fullname.Contains(customerName))
                              && (categoryId == null || customer.CateId == categoryId)
                             && (branchId == null || customer.BranchId == branchId)
                             && (string.IsNullOrEmpty(phone) || customer.Phone.Contains(phone))
                              select new CustomerViewModel
                              {
                                  Active = customer.Active,
                                  Address = customer.Address,
                                  BranchId = customer.BranchId,
                                  BranchName = branch.BranchName,
                                  CateId = customer.CateId,
                                  CateName = cate.CateName,
                                  CitizenId = customer.CitizenId,
                                  CreatedTime = customer.CreatedTime,
                                  CustomerId = customer.CustomerId,
                                  Description = customer.Description,
                                  Email = customer.Email,
                                  Fullname = customer.Fullname,
                                  Phone = customer.Phone,
                                  Photo = customer.Photo,
                              }).ToListAsync();
            }
            else
            {
                data = await (from customer in db.Customer
                              from cate in db.CustomerCategory
                              from branch in db.Branch
                              where customer.Active == 1 && customer.CateId == cate.CateId && cate.Active == 1
                              && customer.BranchId == branch.BranchId && branch.Active == 1
                              && (customer.CustomerId.ToString().Contains(keyword)
                              || customer.Fullname.Contains(keyword)
                              || customer.Phone.Contains(keyword)
                              || cate.CateName.Contains(keyword)
                              || branch.BranchName.Contains(keyword))
                              && ((string.IsNullOrEmpty(customerId) || customer.CustomerId.ToString().Contains(customerId))
                              && (string.IsNullOrEmpty(customerName) || customer.Fullname.Contains(customerName))
                              && (categoryId == null || customer.CateId == categoryId)
                              && (branchId == null || customer.BranchId == branchId)
                              && (string.IsNullOrEmpty(phone) || customer.Phone.Contains(phone)))
                              select new CustomerViewModel
                              {
                                  Active = customer.Active,
                                  Address = customer.Address,
                                  BranchId = customer.BranchId,
                                  BranchName = branch.BranchName,
                                  CateId = customer.CateId,
                                  CateName = cate.CateName,
                                  CitizenId = customer.CitizenId,
                                  CreatedTime = customer.CreatedTime,
                                  CustomerId = customer.CustomerId,
                                  Description = customer.Description,
                                  Email = customer.Email,
                                  Fullname = customer.Fullname,
                                  Phone = customer.Phone,
                                  Photo = customer.Photo,
                              }).ToListAsync();
            }
            data = data.Sort(sortType, column);
            return data;
        }
        public async Task<List<CustomerViewModel>> AdvancedSearch(TableSearchViewModel<CustomerViewModel> tableSearch)
        {
            IQueryable<CustomerViewModel> data = from customer in db.Customer
                                                 from cate in db.CustomerCategory
                                                 from branch in db.Branch
                                                 where customer.Active == 1 && customer.CateId == cate.CateId && cate.Active == 1
                                                 && customer.BranchId == branch.BranchId && branch.Active == 1
                                                 select new CustomerViewModel
                                                 {
                                                     Active = customer.Active,
                                                     Address = customer.Address,
                                                     BranchId = customer.BranchId,
                                                     BranchName = branch.BranchName,
                                                     CateId = customer.CateId,
                                                     CateName = cate.CateName,
                                                     CitizenId = customer.CitizenId,
                                                     CreatedTime = customer.CreatedTime,
                                                     CustomerId = customer.CustomerId,
                                                     Description = customer.Description,
                                                     Email = customer.Email,
                                                     Fullname = customer.Fullname,
                                                     Phone = customer.Phone,
                                                     Photo = customer.Photo,
                                                 };
            var searchOptions = tableSearch.SearchOptions;
            if (searchOptions.CustomerId != null)
            {
                data = data.Where(c => c.CustomerId.ToString().Contains(searchOptions.CustomerId.ToString()));
            }
            if (!string.IsNullOrEmpty(searchOptions.Fullname))
            {
                data = data.Where(c => c.Fullname.ToLower().Contains(searchOptions.Fullname.ToLower()));
            }
            if (searchOptions.CateId != null)
            {
                data = data.Where(c => c.CateId == searchOptions.CateId);
            }
            if (searchOptions.BranchId != null)
            {
                data = data.Where(c => c.BranchId == searchOptions.BranchId);
            }
            if (!string.IsNullOrEmpty(searchOptions.Phone))
            {
                data = data.Where(c => c.Phone.Contains(searchOptions.Phone));
            }
            if (searchOptions.StartDate != null && searchOptions.EndDate != null)
            {
                data = data.Where(c => searchOptions.StartDate <= c.CreatedTime && c.CreatedTime <= searchOptions.EndDate);
            }
            else
            {
                if (searchOptions.StartDate != null)
                {
                    data = data.Where(c => searchOptions.StartDate <= c.CreatedTime);
                }
                else if(searchOptions.EndDate != null)
                {
                    data = data.Where(c => c.EndDate <= searchOptions.CreatedTime);
                }
            }
            if (!string.IsNullOrEmpty(tableSearch.Keyword))
            {
                var keyword = tableSearch.Keyword;
                data = data.Where(c => c.CustomerId.ToString().Contains(keyword)
                                || c.Fullname.Contains(keyword)
                                || c.Phone.Contains(keyword)
                                || c.CateName.Contains(keyword)
                                || c.BranchName.Contains(keyword));
            }
            var result = await data.ToListAsync();
            result = result.Sort(tableSearch.SortType, tableSearch.ColumnSort);
            return result;
        }

        public async Task<List<Branch>> ListBranch()
        {
            return await db.Branch.Where(b => b.Active == 1).ToListAsync();
        }
    }
}

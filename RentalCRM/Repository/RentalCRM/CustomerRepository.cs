using RentalCRM.Models;
using RentalCRM.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RentalCRM.Repository.RentalCRM
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly RentalCRMContext db;
        public CustomerRepository(RentalCRMContext _db)
        {
            db = _db;
        }
        public Task<Customer> Add(Customer model)
        {
            throw new System.NotImplementedException();
        }

        public int Count()
        {
            return db.Customer.Count();
        }

        public Task Delete(Customer model)
        {
            throw new System.NotImplementedException();
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
                          where customer.CateId==cate.CateId && customer.BranchId==branch.BranchId
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
            return await db.CustomerCategory.ToListAsync();
        }

        public Task Update(Customer model)
        {
            throw new System.NotImplementedException();
        }
    }
}

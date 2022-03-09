using RentalCRM.Models;
using RentalCRM.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalCRM.Repository
{
    public interface ICustomerRepository
    {
        Task<List<CustomerViewModel>> List();
        int Count();
        Task<List<CustomerCategory>> ListCustomerCategory();
        Task<CustomerViewModel> GetByCustomerId(int customerId);
        Task<Customer> Add(Customer model);
        Task Update(Customer model);
        Task Delete(Customer model);
        Task<int> DeletePermanently(int customerId);


    }
}

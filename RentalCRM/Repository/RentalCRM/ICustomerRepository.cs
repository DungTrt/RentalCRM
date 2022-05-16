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
        Task<List<Branch>> ListBranch();
        Task<CustomerViewModel> GetByCustomerId(int customerId);
        Task<Customer> Add(Customer model);
        Task Update(Customer model);
        Task Delete(Customer model);
        Task<int> DeletePermanently(int customerId);
        Task<List<CustomerViewModel>> ListPaging(string sortType, string column, 
            string customerId, string customerName, int? categoryId, int? branchId, string phone,string keyword);
        Task<List<CustomerViewModel>> AdvancedSearch(TableSearchViewModel<CustomerViewModel> searchOptions);



    }
}

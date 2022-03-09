using System.Collections.Generic;
using System.Threading.Tasks;
using RentalCRM.Models;
using RentalCRM.ViewModel;

namespace RentalCRM.Repository
{
    public interface IUserRepository
    {
        Task<List<UserViewModel>> List();
        int Count();
        Task<List<Users>> Search(string keyword);
        Task<List<Users>> ListPaging(int pageIndex, int pageSize);
        Task<Users> Detail(int userId);
        Task<Users> Add(Users model);
        Task Update(Users model);
        Task Delete(Users model);
        Task<int> DeletePermanently(int? userId);
    }
}

using RentalCRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalCRM.Repository
{
    public interface IBranchRepository
    {
        Task<List<Branch>> List();
        int Count();
    }
}

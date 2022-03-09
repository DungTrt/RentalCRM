using Microsoft.EntityFrameworkCore;
using RentalCRM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCRM.Repository.RentalCRM
{
    public class BranchRepository : IBranchRepository
    {
        private readonly RentalCRMContext db;
        public BranchRepository(RentalCRMContext _db)
        {
            db = _db;
        }

        public int Count()
        {
            return db.Branch.Where(b => b.Active == 1).Count();
        }

        public async Task<List<Branch>> List()
        {
            return await db.Branch.Where(b => b.Active == 1).ToListAsync();
        }
    }
}

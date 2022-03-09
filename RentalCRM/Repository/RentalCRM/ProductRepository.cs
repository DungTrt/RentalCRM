using RentalCRM.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCRM.Repository.RentalCRM
{
    public class ProductRepository : IProductRepository
    {
        private readonly RentalCRMContext db;
        public ProductRepository(RentalCRMContext _db)
        {
            db = _db;
        }
        public int Count()
        {
            return db.Product.Count();
        }
    }
}

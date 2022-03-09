using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RentalCRM.Controllers.RentalCRM
{
    [Route("bao-cao")]
    [ApiController]
    public class Report : Controller
    {
        [Route("bao-cao-tien-hang")]
        public async Task<IActionResult> ReportCash()
        {
            return View();
        }

        [Route("bao-cao-don-hang")]
        public async Task<IActionResult> ReportOrder()
        {
            return View();
        }

        [Route("bao-cao-san-pham")]
        public async Task<IActionResult> ReportProduct()
        {
            return View();
        }

        [Route("bao-cao-khach-hang")]
        public async Task<IActionResult> ReportCustomer()
        {
            return View();
        }
        [Route("bao-cao-don-ban")]
        public async Task<IActionResult> ReportSalesOrder()
        {
            return View();
        }

        [Route("top-san-pham")]
        public async Task<IActionResult> ReportTopProduct()
        {
            return View();
        }

        [Route("top-khach-hang")]
        public async Task<IActionResult> ReportTopCustomer()
        {
            return View();
        }

        [Route("top-danh-muc-khach-hang")]
        public async Task<IActionResult> ReportRenvenueByCategoryCustomer()
        {
            return View();
        }

        [Route("top--danh-muc-san-pham")]
        public async Task<IActionResult> ReportRenvenueByCategoryProduct()
        {
            return View();
        }

        [Route("phan-hoi-khach-hang")]
        public async Task<IActionResult> OrderRating()
        {
            return View();
        }
    }
}

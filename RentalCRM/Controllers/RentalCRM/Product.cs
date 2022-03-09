using Microsoft.AspNetCore.Mvc;

namespace RentalCRM.Controllers.RentalCRM
{
    [Route("san-pham")]
    [ApiController]
    public class Product : Controller
    {
        [Route("danh-muc-san-pham")]
        public IActionResult ProductCategory()
        {
            return View();
        }

        [Route("tra-cuu-san-pham")]
        public IActionResult SearchProduct()
        {
            return View();
        }

        [Route("danh-sach-san-pham")]
        public IActionResult List()
        {
            return View();
        }

        [Route("danh-sach-combo")]
        public IActionResult ListCombo()
        {
            return View();
        }

        [Route("danh-sach-combo-san-pham")]
        public IActionResult ListProductCombo()
        {
            return View();
        }

        [Route("danh-sach-kho")]
        public IActionResult ListRepository()
        {
            return View();
        }

        [Route("lich-su-cap-nhat-kho")]
        public IActionResult RepositoryLog()
        {
            return View();
        }
    }
}

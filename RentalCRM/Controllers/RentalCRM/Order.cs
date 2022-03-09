using Microsoft.AspNetCore.Mvc;
using RentalCRM.Models;
using RentalCRM.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCRM.Controllers.RentalCRM
{
    //[Route("don-hang")]
    [ApiController]
    public class Order : Controller
    {
        private readonly IOrderRepository repository;
        public Order(IOrderRepository _repository)
        {
            repository = _repository;
        }
        [Route("don-hang/tao-don-hang")]
        public async Task<IActionResult> UpdateOrder()
        {
            return View();
        }

        [Route("don-hang/danh-sach-don-hang")]
        public async Task<IActionResult> List()
        {
            return View();
        }

        [Route("don-hang/thong-tin-dat-hang")]
        public async Task<IActionResult> OrderInformation()
        {
            return View();
        }

        [Route("don-hang/tra-cuu-don-hang")]
        public async Task<IActionResult> OrderDetail()
        {
            return View();
        }

        [Route("don-hang/lich-su-cap-nhat-don")]
        public async Task<IActionResult> OrderLog()
        {
            return View();
        }

        [Route("don-hang/tao-don-ban")]
        public async Task<IActionResult> SalesOrderLost()
        {
            return View();
        }

        [Route("don-hang/danh-sach-don-ban")]
        public async Task<IActionResult> SalesOrder()
        {
            return View();
        }
        [HttpGet]
        [Route("api/reportbycustomer")]
        public async Task<IActionResult> ReportByCustomer(DateTime startDate, DateTime endDate)
        {
            try
            {
                var dataList = await repository.ReportByCustomer(startDate, endDate);

                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }

                var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
                //var response = Newtonsoft.Json.JsonConvert.SerializeObject(novaticResponse);
                return Ok(novaticResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/reportbyproduct")]
        public async Task<IActionResult> ReportByProduct(DateTime startDate, DateTime endDate)
        {
            try
            {
                var dataList = await repository.ReportByProduct(startDate, endDate);

                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }

                var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
                //var response = Newtonsoft.Json.JsonConvert.SerializeObject(novaticResponse);
                return Ok(novaticResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/reportbycustomercategory")]
        public async Task<IActionResult> ReportByCustomerCategory(DateTime startDate, DateTime endDate)
        {
            try
            {
                var dataList = await repository.ReportByCustomerCategory(startDate, endDate);

                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }

                var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
                //var response = Newtonsoft.Json.JsonConvert.SerializeObject(novaticResponse);
                return Ok(novaticResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/reportbyproductcategory")]
        public async Task<IActionResult> ReportByProductCategory(DateTime startDate, DateTime endDate)
        {
            try
            {
                var dataList = await repository.ReportByProductCategory(startDate, endDate);

                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }

                var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
                //var response = Newtonsoft.Json.JsonConvert.SerializeObject(novaticResponse);
                return Ok(novaticResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/reportrevenuebytime")]
        public async Task<IActionResult> ReportRevenueByTime(DateTime startDate, DateTime endDate)
        {
            try
            {
                var dataList = await repository.ReportRevenueByTime(startDate, endDate);

                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }

                var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
                //var response = Newtonsoft.Json.JsonConvert.SerializeObject(novaticResponse);
                return Ok(novaticResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/getrecentorder")]
        public async Task<IActionResult> GetRecentOrder(DateTime startDate, DateTime endDate)
        {
            try
            {
                var dataList = await repository.RecentOrder();

                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }

                var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
                //var response = Newtonsoft.Json.JsonConvert.SerializeObject(novaticResponse);
                return Ok(novaticResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/reportrevenuebybranch")]
        public async Task<IActionResult> ReportRevenueByBranch(DateTime startDate, DateTime endDate)
        {
            try
            {
                var dataList = await repository.ReportRevenueByBranch(startDate, endDate);

                if (dataList == null || dataList.Count() == 0)
                {
                    return NotFound();
                }

                var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
                //var response = Newtonsoft.Json.JsonConvert.SerializeObject(novaticResponse);
                return Ok(novaticResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}

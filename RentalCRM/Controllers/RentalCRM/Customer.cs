using Microsoft.AspNetCore.Mvc;
using RentalCRM.Models;
using RentalCRM.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCRM.Controllers.RentalCRM
{
    //[Route("khach-hang")]
    [ApiController]
    public class Customer : Controller
    {
        private readonly ICustomerRepository repository;
        public Customer(ICustomerRepository _repository)
        {
            repository = _repository;
        }
        [Route("khach-hang/danh-muc-khach-hang")]
        public async Task<IActionResult> CustomerCategory()
        {
            return View();
        }

        [Route("khach-hang/danh-sach-khach-hang")]
        public async Task<IActionResult> ListCustomer()
        {
            return View();
        }

        [HttpGet]
        [Route("customer/api/getlistcustomer")]
        public async Task<IActionResult> GetListCustomer()
        {
            try
            {
                var dataList = await repository.List();

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
        [Route("customer/api/getlistcustomercategory")]
        public async Task<IActionResult> GetListCustomerCategory()
        {
            try
            {
                var dataList = await repository.ListCustomerCategory();

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
    }
}

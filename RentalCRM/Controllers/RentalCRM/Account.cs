using Microsoft.AspNetCore.Mvc;
using RentalCRM.Models;
using RentalCRM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCRM.Controllers.RentalCRM
{

    [ApiController]
    public class Account : Controller
    {
        private IUserRepository repository;
        public Account(IUserRepository _repository)
        {
            repository = _repository;
        }
        [Route("tai-khoan/dang-nhap")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("tai-khoan/danh-muc-tai-khoan")]
        public IActionResult AccountCategory()
        {
            return View();
        }

        [Route("tai-khoan/danh-sach-tai-khoan")]
        public IActionResult List()
        {
            return View();
        }

        [HttpGet]
        [Route("account/api/list")]
        public async Task<IActionResult> ListAccount()
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
    }
}

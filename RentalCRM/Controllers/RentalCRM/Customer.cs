using Microsoft.AspNetCore.Mvc;
using RentalCRM.Models;
using RentalCRM.Repository;
using RentalCRM.ViewModel;
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
        public async Task<IActionResult> GetListCustomer(int pageSize, int pageIndex,
            string sortType, string column,
            string customerId, string customerName, int? categoryId, string cateName, int? branchId, string branchName, string phone, string keyword)
        {
            try
            {
                var recordsTotal = repository.Count();
                var dataList = await repository.ListPaging(sortType, column, customerId, customerName, categoryId, branchId, phone, keyword);
                var recordsFiltered = dataList.Count;
                var data = dataList.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

                if (recordsTotal == 0)
                {
                    return NotFound();
                }

                var novaticResponse = new DionResponseViewModel<CustomerViewModel>
                {
                    RecordsTotal = recordsTotal,
                    RecordsFiltered = recordsFiltered,
                    Data = data
                };
                //var response = Newtonsoft.Json.JsonConvert.SerializeObject(novaticResponse);
                return Ok(novaticResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("customer/api/advancedSearch")]
        public async Task<IActionResult> AdvancedSearch([FromBody] TableSearchViewModel<CustomerViewModel> tableSearch)
        {
            try
            {
                var recordsTotal = repository.Count();
                var dataList = await repository.AdvancedSearch(tableSearch);
                var recordsFiltered = dataList.Count;
                var data = dataList
                    .Skip((tableSearch.PageIndex - 1) * tableSearch.PageSize)
                    .Take(tableSearch.PageSize)
                    .ToList();

                if (recordsTotal == 0)
                {
                    return NotFound();
                }

                var novaticResponse = new DionResponseViewModel<CustomerViewModel>
                {
                    RecordsTotal = recordsTotal,
                    RecordsFiltered = recordsFiltered,
                    Data = data
                };
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

        [HttpGet]
        [Route("customer/api/getlistbranch")]
        public async Task<IActionResult> GetListBranch()
        {
            try
            {
                var dataList = await repository.ListBranch();

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

        [HttpPost]
        [Route("customer/api/Add")]
        public async Task<IActionResult> Add([FromBody] Models.Customer model)
        {
            if (ModelState.IsValid)
            {
                //1. business logic

                //data validation

                model.Active = 1;
                //auto correct
                //model. = 1;

                //2. add new object
                try
                {
                    var newObj = await repository.Add(model);
                    if (newObj.CustomerId > 0)
                    {
                        var novaticResponse = NovaticResponse.CREATED(model);
                        return Created("", novaticResponse);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception e)
                {

                    return BadRequest(e.Message + " - " + e.InnerException);
                }
            }
            return BadRequest();
        }


        [HttpPost]
        [Route("customer/api/Update")]
        public async Task<IActionResult> Update([FromBody] Models.Customer model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //1. business logic 


                    //2. update object
                    await repository.Update(model);

                    var novaticResponse = NovaticResponse.SUCCESS(model);
                    return Ok(novaticResponse);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }
            return BadRequest();
        }


        [HttpPost]
        [Route("customer/api/Delete")]
        public async Task<IActionResult> Delete([FromBody] Models.Customer model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    model.Active = 0;
                    //2. logically delete object
                    await repository.Delete(model);

                    var novaticResponse = NovaticResponse.SUCCESS(model);
                    return Ok(novaticResponse);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}

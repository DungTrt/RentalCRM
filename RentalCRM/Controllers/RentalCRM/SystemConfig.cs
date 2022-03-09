using Microsoft.AspNetCore.Mvc;
using RentalCRM.Models;
using RentalCRM.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCRM.Controllers.RentalCRM
{
    [ApiController]
    public class SystemConfig : Controller
    {
        private readonly IBranchRepository repository;
        public SystemConfig(IBranchRepository _repository)
        {
            repository= _repository;
        }
        [Route("cau-hinh-he-thong/quan-ly-chi-nhanh")]
        public async Task<IActionResult> Branch()
        {
            return View();
        }

        [Route("cau-hinh-he-thong/quan-ly-size")]
        public async Task<IActionResult> ProductSize()
        {
            return View();
        }

        [HttpGet]
        [Route("systemconfig/api/getlistbranch")]
        public async Task<IActionResult> ListBranches()
        {
            try
            {
                var dataList = await repository.List();
                if(dataList == null && dataList.Count==0)
                {
                    return NotFound();
                }
                else
                {
                    var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
                    return Ok(novaticResponse);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

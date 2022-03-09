using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RentalCRM.Models;
using RentalCRM.Repository;
using RentalCRM.Repository.RentalCRM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCRM.Controllers
{
    [Route("")]
    [ApiController]
    public class RentalCRMController : Controller
    {
        private readonly ILogger<RentalCRMController> _logger;
        private readonly IProductRepository productRepository;
        private readonly IBranchRepository branchRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;

        public RentalCRMController(ILogger<RentalCRMController> logger,IProductRepository _productRepository,IBranchRepository _branchRepository,ICustomerRepository _customerRepository,IOrderRepository _orderRepository)
        {
            _logger = logger;
            productRepository = _productRepository;
            branchRepository = _branchRepository;
            customerRepository = _customerRepository; 
            orderRepository = _orderRepository;
        }

        [HttpGet]
        [Route("")]
        [Route("trang-chu")]
        public IActionResult RentalCRMHome()
        {
            ViewBag.ProductCount=productRepository.Count();
            ViewBag.BranchCount=branchRepository.Count();
            ViewBag.CustomerCount = customerRepository.Count();
            ViewBag.OrderCount=orderRepository.Count();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

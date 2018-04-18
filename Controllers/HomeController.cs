using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        private ECommerceContext _context;
 
        public HomeController(ECommerceContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("add_customer")]
        public IActionResult AddCustomer(Customer customer)
        {
            if(ModelState.IsValid){
                _context.Add(customer);
                _context.SaveChanges();
                return Redirect("customers");
            }
            return View("Customer");
        }

        [HttpGet]
        [Route("customers")]
        public IActionResult DisplayCustomers()
        {
            List<Customer> AllCustomers = _context.customers.ToList();
            ViewBag.customers = AllCustomers;
            return View("Customer");
        }

        [HttpGet]
        [Route("orders")]
        public IActionResult DisplayOrders()
        {
            List<Order> AllOrders = _context.orders.Include(order => order.Customer).Include(order => order.Product).ToList();
            List<Customer> AllCustomers = _context.customers.ToList();
            List<Product> AllProducts = _context.products.ToList();
            ViewBag.orders = AllOrders;
            ViewBag.customers = AllCustomers;
            ViewBag.products = AllProducts;
            return View("Order");
        }

        [HttpPost]
        [Route("new_order")]
        public IActionResult NewOrder(Order order)
        {
            if(ModelState.IsValid)
            {
                
            }
            return View();
        }
        
    }
}

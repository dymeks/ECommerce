using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.AspNetCore.Antiforgery;

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
        [ValidateAntiForgeryToken]
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
        [Route("remove/{CustomerId}")]
        public IActionResult RemoveCustomer(int CustomerId)
        {
            Customer RetrievedCustomer = _context.customers.SingleOrDefault(customer => customer.CustomerId == CustomerId);
            _context.customers.Remove(RetrievedCustomer);
            _context.SaveChanges();
            return Redirect("/customers");
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
        [ValidateAntiForgeryToken]
        public IActionResult NewOrder(int customerId, int ProductId, int Quantity)
        {
            Product orderProduct = _context.products.SingleOrDefault(product => product.ProductId == ProductId);
             
            if(orderProduct.ProductQuantity >= Quantity)
            {
                
                orderProduct.ProductQuantity = orderProduct.ProductQuantity - Quantity;
                if(orderProduct.ProductQuantity < 0)
                {
                    ViewBag.error = "There are not enough products to meet the demand.";
                    return View("Order");
                } else {
                    Order order = new Order()
                    {
                        Quantity = Quantity,
                        Date = DateTime.Now,
                        CustomerId = customerId,
                        ProductId = ProductId
                    };
                    _context.orders.Add(order);
                    _context.SaveChanges();
                }
                
                return Redirect("/orders");
            }
        
            ViewBag.error = "Can't order more items then are currently availible.";
            return View("Order");
        }

        [HttpGet]
        [Route("products")]
        public IActionResult DisplayProducts()
        {
            List<Product> AllProducts = _context.products.ToList();
            ViewBag.products = AllProducts;
            return View("Product");
        }
        
        [HttpPost]
        [Route("add_product")]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(Product product)
        {
            if(ModelState.IsValid)
            {
                _context.Add(product);
                _context.SaveChanges();
                return Redirect("/products");
            }

            return View("Product");
        }
    }
}

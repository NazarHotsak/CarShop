using Microsoft.AspNetCore.Mvc;
using CheapCars.Models;
using CheapCars.Models.ViewModels;
using System.Linq;

namespace CheapCars.Controllers
{
    public class OrderController : Controller
    {
        private ICustomerRepository _context;

        public OrderController(ICustomerRepository context)
        {
            _context = context;
        }

        public ViewResult List()
        {
            return View(_context.Customers.OrderBy(customer => customer.Shipped));
        }

        public IActionResult Ship(int CustomerId)
        {
            Customer customer = _context.Customers.FirstOrDefault(customer => customer.CustomerId == CustomerId);

            customer.Shipped = true;

            _context.SaveCustomerData(customer);

            return RedirectToAction(nameof(List));
        }

        public string Sent(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.SaveCustomerData(customer);
            }
            else
            {
                return "Error";
            }

            return "Thanks";
        }
    }
}


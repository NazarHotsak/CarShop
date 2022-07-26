using System.Linq;

namespace CheapCars.Models
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public EFCustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Customer> Customers => _context.Customers;

        public void SaveCustomerData(Customer customer)
        {
            if (customer.CustomerId == 0)
            {
                _context.Customers.Add(customer);
            }

            _context.SaveChanges();
        }
    }
}

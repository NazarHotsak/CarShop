using System.Linq;

namespace CheapCars.Models
{
    public interface ICustomerRepository
    {
        public IQueryable<Customer> Customers { get; }

        public void SaveCustomerData(Customer customer);
    }
}

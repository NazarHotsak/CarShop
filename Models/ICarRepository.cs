using System.Linq;

namespace CheapCars.Models
{
    public interface ICarRepository
    {
        public IQueryable<Car> Cars { get; }
        public void Save(Car car);
        public void Delete(int id);
    }
}

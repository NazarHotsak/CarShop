using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CheapCars.Models
{
    public class EFCarRepository : ICarRepository
    {
        private ApplicationDbContext _context;

        public EFCarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Car> Cars => _context.Cars;

        public void Save(Car car)
        {
            if (car.CarID == 0)
            {
                _context.Cars.Add(car);
            }
            else
            {
                Car cardb = _context.Cars.FirstOrDefault(c => c.CarID == car.CarID);

                if (cardb != null)
                {
                    cardb.Auction = car.Auction;
                    cardb.AuctionDate = car.AuctionDate;
                    cardb.BodyType = car.BodyType;
                    cardb.Brand = car.Brand;
                    cardb.Color = car.Color;
                    cardb.Cut = car.Cut;
                    cardb.Description = car.Description;
                    cardb.DriveType = car.DriveType;
                    cardb.EngineCapacity = car.EngineCapacity;
                    cardb.EngineType = car.EngineType;
                    cardb.Gearbox = car.Gearbox;
                    cardb.FullDuty = car.FullDuty;
                    cardb.Location = car.Location;
                    cardb.Mark = car.Mark;
                    cardb.Mileage = car.Mileage;
                    cardb.Name = car.Name;
                    cardb.NumberOfShipments = car.NumberOfShipments;
                    cardb.Price = car.Price;
                    cardb.Status = car.Status;
                    cardb.SteeringWheelPosition = car.SteeringWheelPosition;
                    cardb.Year = car.Year;
                }
            }

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Car car = _context.Cars.FirstOrDefault(car => car.CarID == id);

            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
        }
    }
}

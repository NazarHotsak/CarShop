using CheapCars.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CheapCars.Models.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using CheapCars.Infrastructure;

namespace CheapCars.Controllers
{
    public class HomeController : Controller
    {
        private const int _topThree= 3;
        private ICarRepository _carRepository;

        public HomeController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public ViewResult Index()
        {
            ViewData["TotalItems"] = _carRepository.Cars.Count();

            return View(new IndexModel()
            {
                Cars = _carRepository.Cars.OrderByDescending(car => car.NumberOfShipments).Take(_topThree).AsEnumerable(),
            });
        }
    }
}


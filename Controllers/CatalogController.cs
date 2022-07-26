using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using CheapCars.Models;
using CheapCars.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using CheapCars.Infrastructure;
using System;

namespace CheapCars.Controllers
{
    public class CatalogController : Controller
    {
        private ICarRepository _carRepository;
        public readonly int PageSize = 1;

        public CatalogController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public ViewResult List(string sortParameters, int page = 1)
        {
            CarFilter carFilter = new(Parse.ParseSortParameters(sortParameters));

            CatalogCarList carListViewModel = new CatalogCarList()
            {
                Cars = FilterCar(carFilter)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .AsEnumerable(),


                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = FilterCar(carFilter)
                    .Count()
                },


                SortParameters = sortParameters,

                CarFilter = carFilter
            };

            ViewData["TotalItems"] = carListViewModel.PagingInfo.TotalPages;

            ViewBag.statusCar = carFilter.StatusCar;

            return View(carListViewModel);
        }

        //[HttpGet("[controller]/[action]/{idCar:int:min(1)}")]
        public ViewResult ViewCar(int idCar = 0)
        {
            return View(new ViewModel()
            {
                Car = _carRepository.Cars.FirstOrDefault(car => car.CarID == idCar),
            });
        }

        public ViewResult AdminList(int page = 1)
        {
            return View(new CatalogCarList()
            {
                Cars = _carRepository.Cars.Skip((page - 1) * PageSize).Take(PageSize),

                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _carRepository.Cars.Count()
                },
            });
        }


        [NonAction]
        private IQueryable<Car> FilterCar(CarFilter carFilter)
        {

            if (carFilter.OK == false)
            {
                return _carRepository.Cars;
            }

            return _carRepository.Cars.Where(car => ((car.FullDuty == carFilter.FullDuty)
                && (car.Cut == carFilter.Cut)
                && ((carFilter.DriveType == null) || (carFilter.DriveType == car.DriveType))
                && ((carFilter.StatusCar == null) || (carFilter.StatusCar == car.Status))
                && ((carFilter.BrandType == null) || (car.Brand.Equals(carFilter.BrandType)))
                && ((carFilter.GearboxType == null) || (car.Gearbox.Equals(carFilter.GearboxType)))
                && ((carFilter.GetSortParameter("Price") == null) || (car.Price >= carFilter.PriceFrom && car.Price <= carFilter.PriceTo))));

        }
    }
}







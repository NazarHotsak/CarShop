using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Collections;
using CheapCars.Models.ViewModels;
using CheapCars.Models;
using System.Linq;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using CheapCars.Infrastructure;

namespace CheapCars.Components
{
    public class CarFilterViewComponent : ViewComponent 
    {
        private readonly ICarRepository _carRepository;
        private IHtmlHelper _htmlHelper;

        public CarFilterViewComponent(ICarRepository carRepository, IHtmlHelper htmlHelper)
        {
            _carRepository = carRepository;
            _htmlHelper = htmlHelper;
        }

        public IViewComponentResult Invoke(string sortParameters, CarFilter carFilter)
        {
            if (carFilter == null)
            {
                carFilter = new CarFilter(Parse.ParseSortParameters(sortParameters));
            }

            IEnumerable<SelectListItem> driveTypes = _htmlHelper.GetEnumSelectList<DriveType>();

            foreach (SelectListItem item in driveTypes)
            {
                item.Selected = item.Value == ((int?)(carFilter?.DriveType ?? null)).ToString();
            }

            return View(new CarFilterModel()
            {
                BrandTypes = new SelectList(_carRepository.Cars.Select(car => car.Brand).Distinct(), carFilter?.BrandType ?? ""),
                GearboxTypes = new SelectList(_carRepository.Cars.Select(car => car.Gearbox).Distinct(), carFilter?.GearboxType ?? ""),
                DriveTypes = driveTypes,
                SortParameters = sortParameters,
                SortParametersFilter = carFilter
            });
        }
    }
}








using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace CheapCars.Models.ViewModels
{
    public class CarFilterModel
    {
        public SelectList GearboxTypes { get; set; }

        public SelectList BrandTypes { get; set; }

        public IEnumerable<SelectListItem> DriveTypes { get; set; }

        public string SortParameters { get; set; }

        public CarFilter SortParametersFilter { get; set; }
    }
}

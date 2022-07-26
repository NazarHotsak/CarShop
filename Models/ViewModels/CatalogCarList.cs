using System.Collections.Generic;

namespace CheapCars.Models.ViewModels
{
    public class CatalogCarList
    {
        public IEnumerable<Car> Cars { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string SortParameters { get; set; }
        public CarFilter CarFilter { get; set; }
    }
}

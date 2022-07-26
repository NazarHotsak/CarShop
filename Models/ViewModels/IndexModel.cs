using System.Collections.Generic;

namespace CheapCars.Models.ViewModels
{
    public class IndexModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public Customer Customer { get; set; }
    }
}

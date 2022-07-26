using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CheapCars.Models.ViewModels
{
    public class SliderModel
    {
        public List<IFormFile> Imgs { get; set; }
    }
}

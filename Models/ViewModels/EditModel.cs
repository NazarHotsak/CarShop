using Microsoft.AspNetCore.Http;

namespace CheapCars.Models.ViewModels
{
    public class EditModel
    {
        public Car Car { get; set; }
        public IFormFile Img { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CheapCars.Models
{
    public enum DriveType
    {
        [Display(Name = "Передній")]
        frontWheel,
        [Display(Name = "Задній")]
        rearWheel,
        [Display(Name = "Повний")]
        fourWheel
    }
}

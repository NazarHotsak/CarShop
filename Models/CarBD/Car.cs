using System.ComponentModel.DataAnnotations;
using System;

namespace CheapCars.Models
{
    public class Car
    {
        [Key]
        public int CarID { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Please enter a car name")]
        public string Name { get; set; }

        [Required]
        public StatusCar Status { get; set; }

        [Required]
        public string Brand { get; set; } 

        [Required(ErrorMessage = "Please enter a car year")]
        public int Year { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int EngineCapacity { get; set; }

        [Required]
        public int Mileage { get; set; } // продіг

        [Required]
        public DriveType DriveType { get; set; }

        [Required]
        [Display(Name = "КПП")]
        [MaxLength(50)]
        public string Gearbox { get; set; } //кпп

        [Required]
        public bool Cut { get; set; } // false = зібраний //зозпил або конструктор  
        
        [Required]
        public bool FullDuty { get; set; } // true = повне мито 

        [MaxLength(20)]
        public string Color { get; set; }

        public int NumberOfShipments { get; set; } = 0;

        public SteeringWheelPosition? SteeringWheelPosition { get; set; } // позиція руля

        public string Description { get; set; }

        public string EngineType { get; set; }

        public string BodyType { get; set; }

        public string Auction { get; set; } //Аукціон

        public double? Mark { get; set; } //Оцінка

        [DataType(DataType.Date)]
        public DateTime? AuctionDate { get; set; }

        public string Location { get; set; }
    }
}
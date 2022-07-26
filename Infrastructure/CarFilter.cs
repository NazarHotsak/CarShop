using System.Collections.Generic;
using CheapCars.Infrastructure;
using System;

namespace CheapCars.Models.ViewModels
{
    public class CarFilter : Filter
    {
        public DriveType? DriveType { get; private set; } 
        public StatusCar? StatusCar { get; private set; } 
        public string GearboxType { get; private set; }
        public bool Cut { get; private set; } = false;
        public bool FullDuty { get; private set; } = true;

        public CarFilter(Dictionary<string, string> sortParameters) : base(sortParameters)
        {
            CreateCarFilter(sortParameters);
        }

        private void CreateCarFilter(Dictionary<string, string> sortParameters) 
        {
            if (sortParameters.Count == 0)
            {
                OK = false;
                return;
            }

            OK = true;

            try
            {
                FullDuty = bool.Parse(sortParameters.GetValueOrDefault("FullDuty"));
                Cut = bool.Parse(sortParameters.GetValueOrDefault("Cut"));
                DriveType = (DriveType?)Parse.ToNullableInt(sortParameters.GetValueOrDefault("DriveType"));
                StatusCar = (StatusCar?)Parse.ToNullableInt(sortParameters.GetValueOrDefault("StatusCar"));
                BrandType = sortParameters.GetValueOrDefault("BrandType");
                GearboxType = sortParameters.GetValueOrDefault("GearboxType");
                PriceFrom = Parse.ParseRangeFrom(sortParameters.GetValueOrDefault("Price"));
                PriceTo = Parse.ParseRangeTo(sortParameters.GetValueOrDefault("Price"));
            }
            catch (Exception)
            {
                OK = false;
            }
        }
    }
}

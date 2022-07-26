using System.Collections.Generic;

namespace CheapCars.Infrastructure
{
    public abstract class Filter
    {
        public int? PriceFrom { get; protected set; }
        public int? PriceTo { get; protected set; }
        public string BrandType { get; protected set; }
        public bool OK { get; protected set; } = false;

        protected Dictionary<string, string> SortParameters { get; set; }

        public Filter(Dictionary<string, string> sortParameters)
        {
            SortParameters = sortParameters;
        }

        public string GetSortParameter(string key)
        {
            return SortParameters.GetValueOrDefault(key);
        }
    }
}

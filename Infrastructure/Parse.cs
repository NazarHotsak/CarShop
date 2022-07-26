using System;
using System.Linq;
using System.Collections.Generic;

namespace CheapCars.Infrastructure
{
    public class Parse
    {
        /// <summary>
        /// Parses sort parameters from string to dictionary<string, string>
        /// </summary>
        public static Dictionary<string, string> ParseSortParameters(string sortParameters)
        {
            Dictionary<string, string> dictionarySortParameters = new Dictionary<string, string>();

            if (sortParameters == null)
            {
                return dictionarySortParameters;
            }

            string[] splitedSortParameters = sortParameters.Split(';', '=');

            if (splitedSortParameters.Length == 0 || splitedSortParameters.Contains("") || splitedSortParameters.Length % 2 == 1)
            {
                return dictionarySortParameters;
            }

            for (int i = 0; i < splitedSortParameters.Length; i++)
            {
                dictionarySortParameters.Add(splitedSortParameters[i], splitedSortParameters[++i]);
            }

            return dictionarySortParameters;
        }

        public static int? ParseRangeFrom(string range)
        {
            if (range == null)
            {
                return null;
            }

            return int.Parse(range.Split('-')[0]);
        }

        public static int? ParseRangeTo(string range)
        {
            if (range == null)
            {
                return null;
            }

            return int.Parse(range.Split('-')[1]);
        }

        public static int? ToNullableInt(string s)
        {
            if (int.TryParse(s, out int i))
            {
                return i;
            }

            return null;
        }
    }
}

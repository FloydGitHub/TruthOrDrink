using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrink.APIinfo
{
    public class BreweryAPI
    {
        public static string GenerateRandomURL()
        {
            return "https://api.openbrewerydb.org/v1/breweries/random";
        }
    }
}

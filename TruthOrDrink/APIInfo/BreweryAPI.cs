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

        public static string GenerateURLByName(string name)
        {
            //getal erachter geeft aan hoeveel brouwerije er terug gegeven worden :)
            return $"https://api.openbrewerydb.org/v1/breweries?by_name={name}&per_page=3";
        }
    }
}

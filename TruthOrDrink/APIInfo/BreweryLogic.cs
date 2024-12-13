using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.APIInfo;

namespace TruthOrDrink.APIinfo
{
    public class BreweryLogic
    {
        public async static Task<List<Brewery>> GetRandomBrewery()
        {
            List<Brewery> breweries = new List<Brewery>();
            string url = BreweryAPI.GenerateRandomURL();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    breweries = JsonConvert.DeserializeObject<List<Brewery>>(json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return breweries;
            }
        }
        public async static Task<List<Brewery>> GetBreweryByName(string name)
        {
            List<Brewery> breweries = new List<Brewery>();
            string url = BreweryAPI.GenerateURLByName(name);
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    breweries = JsonConvert.DeserializeObject<List<Brewery>>(json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return breweries;
            }
        }
    }
}

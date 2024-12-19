using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrink.APIInfo
{
    public class JokeLogic
    {
        public async static Task<Joke> GetRandomJoke()
        {

            string url = JokeApi.GetUrlRandom();
            Joke joke = new Joke();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    joke = JsonConvert.DeserializeObject<Joke>(json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return joke;
            }
        }
    }
}

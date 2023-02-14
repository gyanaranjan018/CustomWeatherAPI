using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace CustomWeatherAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to the Weather API!");
            Console.WriteLine("Enter the Latitude of your location: ");
            decimal Latitude = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter the longitude of you location:");
            decimal Longitude = Convert.ToDecimal(Console.ReadLine());

            string url = $"https://api.open-meteo.com/v1/forecast?latitude={Latitude}&longitude={Longitude}&current_weather=true";

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                var json = response.Content.ReadAsStringAsync().Result;
                var weather = JObject.Parse(json);

                Console.WriteLine("Current Temperature is {0} degree celcius, wind speed is {1} and wind direction is {2}.", Convert.ToString(weather["current_weather"]["temperature"]), Convert.ToString(weather["current_weather"]["windspeed"]), Convert.ToString(weather["current_weather"]["winddirection"]));
            }
        }
    }
}
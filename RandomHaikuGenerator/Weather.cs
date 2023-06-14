using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;

using System.Threading.Tasks;


namespace RandomHaikuGenerator
{

    public interface IWeather
    {
        public bool PrintResult(string result);
    }
    public class Weather : IWeather
    {
        public bool Completed { get; set; }
 
        public bool PrintResult(string weather)
        {
            if (weather == "")
            {
                return false;
            }
            return true;
             
        }

        public async Task requestWeatherAsync()
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/Paris/2020-12-15T13:00:00?key=KBNUHYY998KCHR5U4UPNW5HN8");
            var response = await client.SendAsync(request);
            
           
                response.EnsureSuccessStatusCode(); // Throw an exception if error
                var body = await response.Content.ReadAsStringAsync();

                var resultJson = JsonDocument.Parse(body);
                Completed = PrintResult(resultJson.RootElement.GetProperty("latitude").GetDouble().ToString());
                Console.WriteLine("" +Completed.ToString());

        }
       
    }
}

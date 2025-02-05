using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBot
{
    public class APIController
    {
        public static readonly HttpClient client = new HttpClient();

        public static async Task ApiGetCall()
        {
            string url = "https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&current=temperature_2m,wind_speed_10m&hourly=temperature_2m,relative_humidity_2m,wind_speed_10m";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            } else
            {
                Console.WriteLine($"[API GET CALL ERROR] - {response.StatusCode}");
            }
        }
    }
}

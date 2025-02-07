using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBot
{
    public class APIHandler
    {
        public static readonly HttpClient client = new HttpClient();

        public static async Task<string> ApiGetCall(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
                return responseBody;
            } else
            {
                Console.WriteLine($"[API GET CALL ERROR] - {response.StatusCode}");
                return response.StatusCode.ToString();
            }
        }
    }
}

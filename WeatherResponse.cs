using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;

namespace DevBot
{
    public class WeatherResponse
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
        public CurrentResponse current { get; set; }

        public WeatherResponse()
        {
            latitude = 0f;
            longitude = 0f;
            current = new CurrentResponse();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBot
{
    public class CurrentResponse
    {
        public float apparent_temperature { get; set; }
        public float cloud_cover { get; set; }
        public float wind_speed_10m { get; set; }
        public float precipitation { get; set; }
        public float snowfall { get; set; }
        public float rain { get; set; }
        public float showers { get; set; }
        public float visibility { get; set; }
        public int weather_code { get; set; }

        public CurrentResponse()
        {
            apparent_temperature = 0f;
            cloud_cover = 0f;
            wind_speed_10m = 0f;
            precipitation = 0f;
            snowfall = 0f;
            rain = 0f;
            showers = 0f;
            visibility = 0f;
            weather_code = 0;
        }
    }
}

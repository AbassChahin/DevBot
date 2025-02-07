using Discord;
using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevBot
{
    public class WeatherSlashCommandModule : InteractionModuleBase<SocketInteractionContext>
    {
        private readonly CustomServices _customServices;

        public WeatherSlashCommandModule(CustomServices customServices)
        {
            _customServices = customServices;
        }

        [SlashCommand("weather", "Check the current weather based on latitude and longitude location!")]
        public async Task WeatherCommand(
                [Summary("latitude", "The latitude of the location")] float latitude,
                [Summary("longitude", "The longitude of the location")] float longitude
            )
        {
            _customServices.Log("Weather Command Called");

            await DeferAsync();

            // Unit Vars
            string tempUnit = "fahrenheit";
            string windUnit = "mph";
            string precipitationUnit = "inch";

            // Current Weather Vars
            string temperature = "apparent_temperature";
            string cloudCover = "cloud_cover";
            string windSpeed = "wind_speed_10m";
            string precipitation = "precipitation";
            string snowfall = "snowfall";
            string rain = "rain";
            string showers = "showers";
            string visbility = "visibility";
            string weatherCode = "weather_code";

            string url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&temperature_unit={tempUnit}&wind_speed_unit={windUnit}&precipitation_unit={precipitationUnit}&current={temperature},{cloudCover},{windSpeed},{precipitation},{snowfall},{rain},{showers},{visbility},{weatherCode}";
            string response = await APIHandler.ApiGetCall(url);

            WeatherResponse responseDeserialized = JsonSerializer.Deserialize<WeatherResponse>(response) ?? new WeatherResponse();
            CurrentResponse currentResponse = responseDeserialized.current;

            string weatherResp = $"{currentResponse.weather_code}";
            string tempResp = $"{currentResponse.apparent_temperature}";
            string cloudCoverResp = $"{currentResponse.cloud_cover}";
            string windSpeedResp = $"{currentResponse.wind_speed_10m}";
            string visibilityResp = $"{currentResponse.visibility}";

            Embed embed = _customServices.BuildWeatherEmbed("Weather Information:", $"At Latitude: {latitude} - Longitude: {longitude}", weatherResp, tempResp, cloudCoverResp, windSpeedResp, visibilityResp, Context);
            await FollowupAsync(embed: embed);
        }
    }
}

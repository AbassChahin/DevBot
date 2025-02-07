using Discord;
using Discord.Interactions;

namespace DevBot
{
    public class CustomServices
    {
        public void Log(string log)
        {
            Console.WriteLine($"[CUSTOM SERVICE LOG] - {log}");
        }

        public Embed BuildEmbed(string title, string description, SocketInteractionContext context)
        {
            EmbedBuilder embedBuilder = new EmbedBuilder()
                .WithTitle(title)
                .WithDescription(description)
                .WithColor(Color.Green)
                .WithThumbnailUrl("https://example.com/thumbnail.jpg") // Optional image
                .WithTimestamp(DateTimeOffset.UtcNow)
                .WithFooter("Bot Managed By BoDev")
                .WithAuthor(context.Client.CurrentUser);

            return embedBuilder.Build();
        }

        public Embed BuildWeatherEmbed(string title, string description, string weather, string temp, string cloudCover, string windSpeed, string visibility, SocketInteractionContext context)
        {
            EmbedBuilder embedBuilder = new EmbedBuilder()
                .WithTitle(title)
                .WithDescription(description)
                .WithColor(Color.Green)
                .WithThumbnailUrl("https://example.com/thumbnail.jpg") // Optional image
                .AddField("Weather Description", weather, false)
                .AddField("Temperature (F)", temp, false)
                .AddField("Cloud Cover Percentage", cloudCover, false)
                .AddField("Wind Speed", windSpeed, false)
                .AddField("Visibility", visibility, false)
                .WithTimestamp(DateTimeOffset.UtcNow)
                .WithFooter("Bot Managed By BoDev")
                .WithAuthor(context.Client.CurrentUser);

            return embedBuilder.Build();
        }
    }
}

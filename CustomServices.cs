using Discord;
using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

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
    }
}

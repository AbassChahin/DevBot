using Discord;
using Discord.Net;
using Discord.WebSocket;
using Newtonsoft.Json;
using System.Dynamic;

namespace DevBot
{
    public class ServerHandler
    {
        private ulong guildID = (ulong)Convert.ToInt64(Program.GetEnv("GUILD_ID"));
        private async Task Hello()
        {
            SocketGuild guild = ClientHandler.publicDiscClient.GetGuild(guildID);
            SlashCommandBuilder guildCommand = new SlashCommandBuilder();
            guildCommand.WithName("hello");
            guildCommand.WithDescription("Responds with Hello!");

            try
            {
                await guild.CreateApplicationCommandAsync(guildCommand.Build());
            }
            catch (HttpException exception)
            {
                string errorJson = JsonConvert.SerializeObject(exception.Errors, Formatting.Indented);
                Console.WriteLine(errorJson);
            }
        }

        public async Task SetupCommands()
        {
            await Hello();
        }
    }
}

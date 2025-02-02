using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevBot
{
    public class Bot
    {
        private readonly DiscordSocketClient _client;
        private readonly InteractionService _commands;
        private readonly IServiceProvider _services;

        private ulong guildID = (ulong)Convert.ToInt64(Program.GetEnv("GUILD_ID"));
        private string discordToken = Program.GetEnv("BOT_TOKEN");

        public Bot()
        {
            _client = new DiscordSocketClient();
            _commands = new InteractionService(_client.Rest);
            
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<CustomServices>();
            serviceCollection.AddSingleton(_client);
            serviceCollection.AddSingleton(_commands);

            _services = serviceCollection.BuildServiceProvider();

            _client.Log += LogAsync;
            _client.Ready += ReadyAsync;
            _client.InteractionCreated += InteractionCreatedAsync;
        }

        public async Task RunAsync()
        {
            await _client.LoginAsync(TokenType.Bot, discordToken);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log);
            return Task.CompletedTask;
        }

        private async Task ReadyAsync()
        {
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
            SocketGuild guild = _client.GetGuild(guildID);
            await _commands.RegisterCommandsToGuildAsync(guild.Id);

            Console.WriteLine("BoDevBot Online and Ready!");
        }

        private async Task InteractionCreatedAsync(SocketInteraction interaction)
        {
            SocketInteractionContext context = new SocketInteractionContext(_client, interaction);
            var command = await _commands.ExecuteCommandAsync(context, _services);

            if (!command.IsSuccess)
            {
                Console.WriteLine($"[COMMAND FAILED] - {command.ErrorReason}");
            }
        }
    }
}

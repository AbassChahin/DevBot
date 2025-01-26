using Discord;
using Discord.Net;
using Discord.WebSocket;
using Newtonsoft.Json;
using DotNetEnv;
using System.Dynamic;

public class Program {
    private static DiscordSocketClient _client;
    private static ulong guildID = (ulong) Convert.ToInt64(GetEnv("GUILD_ID"));
    
    public static async Task Main()
    {
        Env.Load();

        _client = new DiscordSocketClient();
        _client.Log += Log;
        _client.Ready += ClientReady;

        string discordToken = GetEnv("BOT_TOKEN");
        await _client.LoginAsync(TokenType.Bot, discordToken);
        await _client.StartAsync();

        await Task.Delay(-1);
    }

    private static Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }

    private static async Task ClientReady()
    {
        SocketGuild guild = _client.GetGuild(guildID);
        SlashCommandBuilder guildCommand = new SlashCommandBuilder();
        guildCommand.WithName("testing");
        guildCommand.WithDescription("testing");

        try
        {
            await guild.CreateApplicationCommandAsync(guildCommand.Build());
        } catch(HttpException exception) {
            string errorJson = JsonConvert.SerializeObject(exception.Errors, Formatting.Indented);
            Console.WriteLine(errorJson);
        }
    }

    private static string GetEnv(string envName)
    {
        return Environment.GetEnvironmentVariable(envName);
    }
}

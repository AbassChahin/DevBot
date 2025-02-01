using Discord.WebSocket;
using DotNetEnv;
using DevBot;

public class Program {
    public static async Task Main()
    {
        Env.Load();
        ClientHandler clientHandler = ClientHandler.GetInstance();
        await clientHandler.InitDiscordClient();
    }



    public static string GetEnv(string envName)
    {
        return Environment.GetEnvironmentVariable(envName);
    }
}

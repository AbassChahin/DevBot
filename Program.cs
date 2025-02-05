using Discord.WebSocket;
using DotNetEnv;
using DevBot;

public class Program {
    private static async Task Main(string[] args)
    {
        await APIController.ApiGetCall();
        Env.Load();
        await new Bot().RunAsync();
    }

    public static string GetEnv(string envName)
    {
        return Environment.GetEnvironmentVariable(envName);
    }
}

using Discord;
using Discord.WebSocket;

namespace DevBot
{
    public class ClientHandler
    {
        private static readonly Lazy<ClientHandler> clientHandlerLazy =
        new Lazy<ClientHandler>(() => new ClientHandler(), LazyThreadSafetyMode.ExecutionAndPublication);

        private static DiscordSocketClient discClient;
        public static DiscordSocketClient publicDiscClient;

        private ClientHandler() { }

        public static ClientHandler GetInstance() {
            return clientHandlerLazy.Value;
        }

        public async Task InitDiscordClient()
        {
            if (discClient == null) {
                await PrepDiscordClient();
            }
        }

        private async Task PrepDiscordClient()
        {
            discClient = new DiscordSocketClient();
            discClient.Log += ClientLog;
            discClient.Ready += ClientReady;
            discClient.SlashCommandExecuted += SlashCommandHandler;
            string discordToken = Program.GetEnv("BOT_TOKEN");
            await discClient.LoginAsync(TokenType.Bot, discordToken);
            await discClient.StartAsync();
            publicDiscClient = discClient;
            await Task.Delay(-1);
        }

        private static Task ClientLog(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private static async Task ClientReady()
        {
            await SetupCommands();
            Console.WriteLine("BoDevBot Online!");
        }

        private static async Task SlashCommandHandler(SocketSlashCommand command)
        {
            if (command.Data.Name.Equals("hello"))
            {
                await command.RespondAsync("Hello!");
            }
        }

        private static async Task SetupCommands()
        {
            ServerHandler serverHandler = new ServerHandler();
            await serverHandler.SetupCommands();
        }
    }
}

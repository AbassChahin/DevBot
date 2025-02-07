using DevBot;

public class Program {
    private static async Task Main(string[] args)
    {
        EnvHandler envHandler = new EnvHandler();
        await new Bot().RunAsync();
    }
}

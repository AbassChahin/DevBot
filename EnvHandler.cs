using DotNetEnv;

namespace DevBot
{
    public class EnvHandler
    {
        public EnvHandler() {
            Env.Load();
        }

        public static string GetEnv(string envName)
        {
            string defaultValue = "";
            return Environment.GetEnvironmentVariable(envName) ?? defaultValue;
        }
    }
}

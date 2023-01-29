using BeziBot.Configuration;
using Microsoft.Extensions.Configuration;

namespace BeziBot.Extensions
{
    internal static class ConfigurationExtensions
    {
        public static string GetBotToken(this IConfiguration configuration)
        {
            return configuration.Get<UserSecrets>()!.Credentials!.BotToken!;
        }

        public static string GetLavalinkPassword(this IConfiguration configuration)
        {
            return configuration.Get<UserSecrets>()!.Credentials!.LavalinkPassword!;
        }
    }
}

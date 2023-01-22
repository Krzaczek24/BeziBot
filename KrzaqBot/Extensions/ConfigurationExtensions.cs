using KrzaqBot.Configuration;
using Microsoft.Extensions.Configuration;

namespace KrzaqBot.Extensions
{
    internal static class ConfigurationExtensions
    {
        public static string GetBotToken(this IConfigurationRoot configuration)
        {
            return configuration.Get<UserSecrets>()!.Credentials!.BotToken!;
        }

        public static string GetLavalinkPassword(this IConfigurationRoot configuration)
        {
            return configuration.Get<UserSecrets>()!.Credentials!.LavalinkPassword!;
        }
    }
}

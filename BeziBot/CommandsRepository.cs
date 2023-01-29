using Discord;
using System.Collections.Generic;
using System.Linq;

namespace BeziBot
{
    internal static class CommandsRepository
    {
        #region SlashCommands (max 100 global && max 100 per guild)
        private static List<SlashCommandProperties> GetSlashCommands()
        {
            return new List<SlashCommandProperties>
            {
                new SlashCommandBuilder()
                    .WithName("decode-emoji")
                    .WithDescription("Poznaj unicode dla podanych emoji")
                    .WithDefaultMemberPermissions(GuildPermission.Administrator)
                    .AddOption("emoji", ApplicationCommandOptionType.String, "Emoji których kody chcesz poznać", true)
                    .Build(),
                new SlashCommandBuilder()
                    .WithName("clear-channel")
                    .WithDescription("Usuń wiadomości kanału")
                    .WithDefaultMemberPermissions(GuildPermission.ManageMessages)
                    .Build(),
                new SlashCommandBuilder()
                    .WithName("join")
                    .WithDescription("Bot dołączy do kanału głosowego w celu odtwarzania muzyki")
                    .AddOption("kanał", ApplicationCommandOptionType.Channel, "Nazwa kanału", true, channelTypes: new[] { ChannelType.Voice }.ToList())
                    .Build(),
                new SlashCommandBuilder()
                    .WithName("play")
                    .WithDescription("Włącz muzykę")
                    .AddOption("utwór", ApplicationCommandOptionType.String, "Nazwa i/lub twórca utworu który chcesz włączyć", true)
                    .Build(),
                new SlashCommandBuilder()
                    .WithName("leave")
                    .WithDescription("Bot opuści kanał głosowy w celu zaprzestania odtwarzania muzyki")                    
                    .Build()
            };
        }
        #endregion

        #region ContextMenuCommands (max 5 global && max 5 per guild)
        private static List<UserCommandProperties> GetUserCommands()
        {
            return new List<UserCommandProperties>
            {
                new UserCommandBuilder()
                    .WithName("User Command")
                    .Build()
            };
        }

        private static List<MessageCommandProperties> GetMessageCommands()
        {
            return new List<MessageCommandProperties>
            {
                new MessageCommandBuilder()
                    .WithName("Message Command")
                    .Build()
            };
        }
        #endregion

        internal static List<ApplicationCommandProperties> GetAllCommands()
        {
            var commands = new List<ApplicationCommandProperties>();
            commands.AddRange(GetSlashCommands());
            commands.AddRange(GetUserCommands());
            commands.AddRange(GetMessageCommands());
            return commands;
        }
    }
}

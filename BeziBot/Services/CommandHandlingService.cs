using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace BeziBot.Services
{
    public class CommandHandlingService
    {
        private readonly IServiceProvider _services;
        private readonly DiscordSocketClient _discord;
        private readonly CommandService _commands;

        public CommandHandlingService(IServiceProvider services, DiscordSocketClient discord, CommandService commands)
        {
            (_commands = commands).CommandExecuted += CommandExecutedAsync;
            (_discord = discord).MessageReceived += MessageReceivedAsync;
            _services = services;
        }

        public async Task InitializeAsync()
        {
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        public async Task MessageReceivedAsync(SocketMessage rawMessage)
        {
            if (!(rawMessage is SocketUserMessage message))
                return;

            if (message.Source != MessageSource.User)
                return;

            var argPos = 0;
            // (!message.HasCharPrefix('!', ref argPos))
            if (!message.HasMentionPrefix(_discord.CurrentUser, ref argPos))
                return;

            var context = new SocketCommandContext(_discord, message);
            await _commands.ExecuteAsync(context, argPos, _services);
        }

        public async Task CommandExecutedAsync(Optional<CommandInfo> command, ICommandContext context, IResult result)
        {
            if (!command.IsSpecified)
                return;

            if (result.IsSuccess)
                return;

            await context.Channel.SendMessageAsync($"error: {result}");
        }
    }
}

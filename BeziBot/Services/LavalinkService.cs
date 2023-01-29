using DisCatSharp;
using Discord;
using Discord.WebSocket;
using BeziBot.Enums;
using BeziBot.Extensions;
using Microsoft.Extensions.Configuration;
using SharpLink;
using System.Threading.Tasks;

namespace BeziBot.Services
{
    public class LavalinkService
    {
        private const string _host = "localhost";
        private const int _port = 2333;
        private readonly LavalinkManager _lavalink;      
        private MusicProviders _musicProvider = MusicProviders.YouTube;

        public LavalinkService(IConfiguration config, DiscordSocketClient discord)
        {
            _lavalink = new LavalinkManager(discord, new LavalinkManagerConfig()
            {
                RESTHost = _host,
                RESTPort = _port,
                WebSocketHost = _host,
                WebSocketPort = _port,
                Authorization = config.GetLavalinkPassword(),
                TotalShards = 1
            });

            discord.Ready += async () => await _lavalink.StartAsync();
        }

        public async Task Run(ulong guildId, IVoiceChannel voiceChannel)
        {
            var player = _lavalink!.GetPlayer(guildId) ?? await _lavalink.JoinAsync(voiceChannel);
        }

        public void SetMusicProvider(MusicProviders provider)
        {
            _musicProvider = provider;
        }
    }
}

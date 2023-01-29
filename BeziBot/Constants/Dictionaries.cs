using BeziBot.Enums;
using System.Collections.Generic;

namespace BeziBot.Constants
{
    public static class Dictionaries
    {
        public static IReadOnlyDictionary<MusicProviders, string> MusicProviderSearchKeyword { get; } = new Dictionary<MusicProviders, string>()
        {
            [MusicProviders.YouTube] = "ytsearch",
            [MusicProviders.Spotify] = "",
            [MusicProviders.SoundCloud] = "scsearch"
        };
    }
}

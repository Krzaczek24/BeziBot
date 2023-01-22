using Discord;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace KrzaqBot.Extensions
{
    internal static class MessageExtensions
    {
        public static ulong[] GetMentionedUserIds(this IUserMessage msg)
        {
            var idList = new List<ulong>();

            foreach (Match match in Regex.Matches(msg.Content, @"<@\d+>"))
            {
                if (MentionUtils.TryParseUser(match.Value, out ulong userId))
                {
                    idList.Add(userId);
                }
            }

            return idList.ToArray();
        }

        public static bool HasMention(this IUserMessage msg, IUser user)
        {
            return msg.GetMentionedUserIds().Contains(user.Id);
        }
    }
}

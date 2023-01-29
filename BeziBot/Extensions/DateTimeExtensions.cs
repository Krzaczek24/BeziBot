using System;
using System.Collections.Generic;

namespace BeziBot.Extensions
{
    internal static class DateTimeExtensions
    {
        public static string FormatTime(this TimeSpan timeSpan)
        {
            var result = new List<string>();

            if (timeSpan.Days > 0)
                result.Add($"{timeSpan.Days}d");
            if (timeSpan.Hours > 0 || result.Count > 0)
                result.Add($"{timeSpan.Hours}h");
            if (timeSpan.Minutes > 0 || result.Count > 0)
                result.Add($"{timeSpan.Minutes}m");
            if (timeSpan.Seconds > 0 || result.Count > 0)
                result.Add($"{timeSpan.Seconds}s");

            return string.Join(" ", result);
        }
    }
}

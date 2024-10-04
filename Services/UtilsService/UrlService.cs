using System;
using System.Text.RegularExpressions;

namespace DonMacaron.Services.UtilsService;

public partial class UrlService
{
    [GeneratedRegex("[^a-z0-9\\-]", RegexOptions.Compiled)]
    private static partial Regex InvalidCharsRegex();

    [GeneratedRegex("\\-{2,}", RegexOptions.Compiled)]
    private static partial Regex MultipleDashesRegex();

    public static string ToUrlFriendly(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        string result = input.ToLowerInvariant();

        result = result.Replace(" ", "-");

        result = InvalidCharsRegex().Replace(result, "");

        result = MultipleDashesRegex().Replace(result, "-");

        result = result.Trim('-');

        return result;
    }
}
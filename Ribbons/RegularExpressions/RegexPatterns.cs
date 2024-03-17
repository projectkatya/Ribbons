using System.Collections.Generic;

namespace Ribbons.RegularExpressions
{
    public static class RegexPatterns
    {
        private static readonly Dictionary<RegexPatternType, string> PatternTypes = new()
        {
            [RegexPatternType.AlphaNumericDotUnderscore] = "^[a-zA-Z0-9._]+$"
        };

        public static string Get(RegexPatternType patternType)
        {
            if (PatternTypes.TryGetValue(patternType, out string pattern))
            {
                return pattern;
            }

            return null;
        }
    }
}
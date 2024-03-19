using Ribbons.RegularExpressions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Ribbons.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class RegexAttribute : ValidationAttribute
    {
        private string Pattern { get; }

        public RegexAttribute(RegexPatternType patternType)
        {
            Pattern = RegexPatterns.Get(patternType);
        }

        public RegexAttribute(string pattern)
        {
            Pattern = pattern;
        }

        public override bool IsValid(object value)
        {
            string str = (string)value;

            if (str == null)
            {
                return false;
            }

            return Regex.IsMatch(str, Pattern);
        }
    }
}
using System.Text.RegularExpressions;
using System;

namespace casehelper
{
    public static class StringExtension
    {
        private const string SNAKE_PATTERN = "_[a-z]";
        private const string CAMEL_PATTERN = "[a-z][A-Z]";
        private const string START_UP = "^[A-Z]";
        private const string START_LOW = "^[a-z]";
        private static MatchEvaluator toCamel = new MatchEvaluator(ToCamel);
        private static MatchEvaluator toSnake = new MatchEvaluator(ToSnake);
        private static MatchEvaluator toLower = new MatchEvaluator(ToLower);
        private static MatchEvaluator toUpper = new MatchEvaluator(ToUpper);

        public static string ToSnakeCase(this string words)
        {
            string retorno = "";
            try
            {
                retorno = Regex.Replace(words, CAMEL_PATTERN, toSnake,
                                                RegexOptions.IgnorePatternWhitespace,
                                                TimeSpan.FromSeconds(.25));
            }
            catch (RegexMatchTimeoutException)
            {
                retorno = null;
            }
            return retorno;
        }
        public static string StartLower(this string word)
        {
            string retorno = "";
            try
            {
                retorno = Regex.Replace(word, START_UP, toLower,
                                                RegexOptions.IgnorePatternWhitespace,
                                                TimeSpan.FromSeconds(.25));
            }
            catch (RegexMatchTimeoutException)
            {
                retorno = null;
            }
            return retorno;
        }
        public static string StartUpper(this string word)
        {
            string retorno = "";
            try
            {
                retorno = Regex.Replace(word, START_LOW, toUpper,
                                                RegexOptions.IgnorePatternWhitespace,
                                                TimeSpan.FromSeconds(.25));
            }
            catch (RegexMatchTimeoutException)
            {
                retorno = null;
            }
            return retorno;
        }
        public static string ToCamelCase(this string words)
        {
            string retorno = "";
            try
            {
                retorno = Regex.Replace(words, SNAKE_PATTERN, toCamel,
                                                RegexOptions.IgnorePatternWhitespace,
                                                TimeSpan.FromSeconds(.25));
            }
            catch (RegexMatchTimeoutException)
            {
                retorno = null;
            }
            return retorno;
        }

        public static string ToCamel(Match match)
        {
            if (match.Length == 0)
                return match.Value;
            var last = match.Value.Length - 1;
            return new string(char.ToUpper(match.Value[last]), 1);


        }
        public static string ToSnake(Match match)
        {
            if (match.Length == 0)
                return match.Value;
            var ret = "_";
            return match.Value[0] + ret + char.ToLower(match.Value[1]);


        }
        public static string ToLower(Match match)
        {
            return match.Value.ToLower();
        }
        public static string ToUpper(Match match)
        {
            return match.Value.ToUpper();
        }

    }
}
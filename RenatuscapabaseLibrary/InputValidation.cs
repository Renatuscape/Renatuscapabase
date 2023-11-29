using System.Text.RegularExpressions;

namespace RenatuscapabaseLibrary
{
    public static class InputValidation
    {
        public static string SanitiseName(string text)
        {
            return Regex.Replace(text, @"[^\w]", "");
        }
    }
}

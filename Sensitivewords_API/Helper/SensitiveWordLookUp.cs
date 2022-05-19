using System.Text;

namespace Sensitivewords_API.Helper
{
    public static class SensitiveWordLookUp
    {
        public static string StarOutWord(string word)
        {
            var length = word.Length;
            var masked = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                if(word[i] == '*')
                {
                    return masked.ToString() + " * FROM sensitiveWords";
                }

                masked.Append("*");
            }

            return masked.ToString() + " * FROM sensitiveWords";
        }

    }
}

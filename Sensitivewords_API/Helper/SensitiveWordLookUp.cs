using System.Text;

namespace Sensitivewords_API.Helper
{
    public static class SensitiveWordLookUp
    {
     
            public static string StarOutWord(string word)
            {
                var staredWord = new StringBuilder();
                for (var x = 0; x < word.Length; x++)
                {
                staredWord.Append("*");
                }
                return staredWord.ToString();
            }
        

    }
}

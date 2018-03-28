using System;
using System.Text;
using System.Linq;

namespace Library
{
    public static class Palindromes
    {
        public static bool IsPalindrome(string palindrome)
        {
            if (string.IsNullOrWhiteSpace(palindrome)) return false;
            var allowedCharacters = new StringBuilder();
            foreach(var c in palindrome)
            {
                if (char.IsLetter(c)) allowedCharacters.Append(Char.ToLowerInvariant(c));
            }
            var limitedString = allowedCharacters.ToString();
            var reversedString = new string(limitedString.Reverse().ToArray());

            if (reversedString == limitedString) return true;
            return false;
        }
    }
}

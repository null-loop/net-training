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
            var limitedString = RemoveCharacters(palindrome);
            var loweredString = limitedString.ToLowerInvariant();
            var reversedString = new string(loweredString.Reverse().ToArray());

            if (reversedString == loweredString) return true;
            return false;
        }

        private static string RemoveCharacters(string original)
        {
            return new string(original.Where(c=>char.IsLetter(c)).ToArray());
        }
    }
}

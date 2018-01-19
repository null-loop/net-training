using FluentAssertions;
using Functions;
using Xunit;

namespace FunctionTesting
{
    public class PalindromeTests
    {
        [Theory]
        [InlineData("radar", true)]
        [InlineData("anna", true)]
        [InlineData("Civic", true)]
        [InlineData("DEVOVED", true)]
        [InlineData("Aibohphobia", true)]
        [InlineData("lard", false)]
        [InlineData("Palindrome", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void IsSimplePalindrome(string text, bool isPalindrome)
        {
            Palindromes.IsPalindrome(text).Should().Be(isPalindrome);
        }

        [Theory]
        [InlineData("Do nine men interpret? Nine men. I nod.", true)]
        [InlineData("A dog! A panic in a pagoda!", true)]
        [InlineData("A Toyota! Race fast, safe car! A Toyota!", true)]
        [InlineData("Are we not pure? \"No sir!\" Panama’s moody Noriega brags. \"It is garbage!\" Irony dooms a man; a prisoner up to new era.", true)]
        [InlineData("Not a palindrome", false)]
        public void IsAdvancedPalindrome(string text, bool isPalindrome)
        {
            Palindromes.IsPalindrome(text).Should().Be(isPalindrome);
        }
    }
}

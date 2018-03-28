using FluentAssertions;
using Library;
using Xunit;

namespace UnitTests
{
    public class LargestIntegerTests
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 }, 4)]
        [InlineData(new int[] { 100, 1000, 2000, 5 }, 2000)]
        [InlineData(new int[] { 100000, 1000, 2000, 5 }, 100000)]
        [InlineData(new int[] { 1000, 1000, 1000, 5 }, 1000)]
        public void CorrectValueIsSelectedFromArray(int[] array, int expectedMax)
        {
            LargestInteger.FindLargest(array).Should().Be(expectedMax);
        }
    }
}

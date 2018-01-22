using FluentAssertions;
using Functions;
using Xunit;

namespace FunctionTesting
{
    public class LeapYearTests
    {
        [Theory]
        [InlineData(1997)]
        [InlineData(1901)]
        [InlineData(1933)]
        public void NonDivisibleByFourReturnsFalse(int year)
        {
            LeapYears.IsLeapYear(year).Should().Be(false);
        }

        [Theory]
        [InlineData(1996)]
        [InlineData(2004)]
        [InlineData(2020)]
        public void DivisibleByFourAndNotByOneHundredReturnsTrue(int year)
        {
            LeapYears.IsLeapYear(year).Should().Be(true);
        }

        [Theory]
        [InlineData(1700)]
        [InlineData(1800)]
        [InlineData(1900)]
        public void DivisibleByFourAndByOneHundredButNotByFourHundredReturnsFalse(int year)
        {
            LeapYears.IsLeapYear(year).Should().Be(false);
        }

        [Theory]
        [InlineData(1600)]
        [InlineData(2000)]
        public void DivisibleByFourAndByOneHundredAndByFourHundredReturnsTrue(int year)
        {
            LeapYears.IsLeapYear(year).Should().Be(true);
        }
    }
}
using System;
using System.Collections.Generic;

namespace Library
{
    public static class LeapYears
    {
        public static bool IsLeapYear(int year)
        {
            var divisibleByFour = year % 4 == 0;
            if (!divisibleByFour) return false;

            var divisibleByHundred = year % 100 == 0;
            if (!divisibleByHundred) return true;

            var divisibleByFourHundred = year % 400 == 0;
            if (!divisibleByFourHundred) return false;

            return true;
        }
    }
}
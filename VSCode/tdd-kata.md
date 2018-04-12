# Test Driven Development Kata

### What's a Kata?

A Japanese word, literally translates as "form", meaning a detailed choreographed pattern of movements in martial arts.

In software engineering it refers to a repeatable exercise designed to teach "best practice".

This Kata will reinforce the Test Driven Development methodology by following the Red/Green/Refactor pattern for a simple problem.

## Pattern

1. Write tests for the requirement
2. Get the tests to compile and fail
3. Get the tests to pass
4. Tidy your code
5. Move to next requirement
6. Repeat until all requirements are met.

## Background

To produce a type called StringCalculator which can take a string of numbers and calculate the sum of the numbers. The type should be called StringCalculator and it should have a single method called Add that takes a string and returns an int:

```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            throw new NotImplementedException("Your implementation goes here!");
        }
    }
}
```

Your test harness will look something like:

```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Xunit;
using Library;

namespace UnitTests
{
    public class StringCalculatorTests
    {
        private void Test_Calculator(string numbers, int expected)
        {
            var calculator = new StringCalculator();
            calculator.Add(numbers).Should().Be(expected);
        }

        public void Empty_String_Returns_0()
        {
            Test_Calculator("", 0);
        }

        // More tests go here...
    }
}
```

It might be worth taking it in turns, one writes the test, one implements it. Or one writes the tests / implementation for one requirement, then switches over to the other person for the next requirement.

## Requirements

1. The Add method can take 0, 1 or 2 numbers in the string (separated by commas) and will return their sum, empty values should be ignored:
    * For an empty string it will return 0
    * For a string of "1,2" it will return 3
    * For a string of "1" it will return 1
    * For a string of "," it will return 0
    * For a string of "10," it will return 10 
2. Allow the Add method to handle an unknown amount of numbers:
    * For a string of "1,10,5,99,100" it will return 215
    * For a string of "1,1,1,1,0,0," it will return 4
3. Allow the Add method to accept commas and new lines as the number separator:
    * For a string of "1\n5,10" it will return 16
    * For a string of "5,5,\n10" it will return 20
4. Allow the optional specification of a different separator character. This will be specified by having a first line like "//;" which will specify that ; is to be used as the separator:
    * For a string of "//;\n1;5;10" it will return 16
    * For a string of "//.\n8.2\n5" it will return 15
5. Prevent the inclusion of negative numbers. When a negative is found - an exception should be thrown with a message of "Negatives are not allowed : {number}" where {number} is the number that was passed. If there are multiple negatives then all of the values should be included:
    * For a string of "1,-10" an exception with the message "Negatives are not allowed : -10" will be thrown
    * For a string of "1,-10,-20" an exception with the message "Negatives are not allowed : -10, -20" will be thrown
6. Numbers larger than 1,000 should be ignored.
    * For a string of "1,1000" it will return 1001
    * For a string of "1,1001" it will return 1
7. Allow the Add method to accept separators longer than 1 character:
    * For a string of "//[--]\n1--2--3" it will return 6
    * For a string of "//[....]\n5....10....20" it will return 35
8. Allow multiple separators to be specified:
    * For a string of "//[.][,]\n1.2,3,4" it will return 10
    * For a string of "//[--][..]\n2--4..6..8" it will return 20

### The Final Test

You should be able to handle **any** character sequence as the separator... so test for the following:

* For a string of "//[00][11]\n2211330044" it will return 99
* For a string of "//[00][11]\n2011500100" it will return 26
* For a string of "//[\t\t][\~~]\n22~~33\t\t44" it will return 99

### Things to remember...

* Name your tests to reflect the requirement:
    * Empty_String_Returns_0
    * Single_Value_Returns_Correct_Sum
    * Two_Values_Returns_Correct_Sum
* If you want to have multiple tests for the same test method:
```C#
[Theory]
[InlineData("1,1000", 1001)]
[InlineData("1,1001", 1)]
public void Numbers_Larger_Than_1000_Are_Ignored(string numbers, int expected)
{
    Test_Calculator(numbers, expected);
}
```
* It's OK to rewrite your implementation - you're meant to - the tests act as your safety net
* If a previous test breaks - fix it! Not by changing the test but by changing your implementation
* You test for the throwing of an exception like so:
    * `Test_Calculator("1,-10", 0).Should().Throw<Exception>().WithMessage("Negatives are not allowed : -10");`
* The provided examples are not exhaustive - you can add additional examples to your tests to improve your coverage

### When you're done...

Notice how you now have tests that cover all the requirements. Also notice that the test code isn't very easy to read as a non-programmer. This will lead us to the next session - SpecFlow - where you write your tests in human readable form.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Xunit;

namespace StringCalculatorTDD
{
    public class StringCalculatorTests
    {
        [Fact]
        public void Add_Empty_String_Gives_Result_Of_0()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add(string.Empty);
            result.Should().Be(0);
        }

        [Fact]
        public void Add_Single_Number_In_String_Returns_That_Number()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("1");
            result.Should().Be(1);
        }

        [Fact]
        public void Add_Two_Numbers_In_String_Returns_The_Correct_Result()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("1,5");
            result.Should().Be(6);
        }

        [Fact]
        public void Add_Three_Numbers_In_String_Returns_The_Correct_Result()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("1,5,8");
            result.Should().Be(14);
        }

        [Fact]
        public void Add_Six_Numbers_In_String_Returns_The_Correct_Result()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("1,5,8,10,20,1000");
            result.Should().Be(1044);
        }

        [Fact]
        public void String_Delimited_By_NewLines_Also_Adds_Correctly()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("1\n5,8,10,20\n1000");
            result.Should().Be(1044);
        }

        [Fact]
        public void Can_Specify_Delimiter_At_Beginnning_Of_String()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("//;\n1;2;3");
            result.Should().Be(6);
        }

        [Fact]
        public void Specified_Delimiter_Also_Allows_Newline()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("//;\n1;2\n3");
            result.Should().Be(6);
        }

        [Fact]
        public void Cannot_Include_Negative_Numbers()
        {
            var calculator = new StringCalculator();
            Action action = () => calculator.Add("-100,10,-1");
            action.Should().Throw<ArgumentException>("Negatives not allowed : -100, -10");
        }

        [Fact]
        public void Numbers_Larger_Than_1000_Ignored()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("1,1001");
            result.Should().Be(1);
        }

        [Fact]
        public void Can_Specify_Delimiters_Longer_Than_1_Character()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("//[--]\n1--2--3");
            result.Should().Be(6);
        }

        [Fact]
        public void Can_Specify_Multiple_Delimiters()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("//[.][,]\n1,2.3");
            result.Should().Be(6);
        }

        [Fact]
        public void Can_Specify_Multiple_Delimiters_Longer_Than_1_Character()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("//[--][...]\n2--4...6...8");
            result.Should().Be(20);
        }

        [Theory]
        [InlineData("//[00][11]\n2211330044", 99)]
        [InlineData("//[00][11]\n2011500100", 26)]
        [InlineData("//[00][11]\n20115000100", 26)]
        [InlineData("//[\t\t][~~]\n22~~33\t\t44", 99)]
        public void Evil_Tests(string input, int expected)
        {
            var calculator = new StringCalculator();
            var result = calculator.Add(input);
            result.Should().Be(expected);
        }

        public void Test_For_Exception()
        {
            var calculator = new StringCalculator();
            Action action = () => calculator.Add("-10,-100");
            action.Should().Throw<Exception>("Not allowed negatives.....");
        }
    }

    public class StringCalculator
    {
        private const string DefaultDelimiter = ",";

        public int Add(string numbers)
        {
            var delimiters = new List<string>();
            var numbersWithoutDelimiterSpec = ParseDelimiters(numbers, delimiters);

            AddDefaultDelimiters(delimiters);

            return Add(numbersWithoutDelimiterSpec, delimiters);
        }

        private static void AddDefaultDelimiters(List<string> delimiters)
        {
            if (!delimiters.Any()) delimiters.Add(DefaultDelimiter);
            delimiters.Add("\n");
        }

        private static string ParseDelimiters(string workingNumbers, List<string> delimiters)
        {
            if (workingNumbers.Length > 2 && workingNumbers.StartsWith("//"))
            {
                var delimiterParts = workingNumbers.Split('\n');
                // skip the first two characters
                var delimiterString = delimiterParts[0].Substring(2);
                // if it's one char long use that...
                if (delimiterString.Length == 1)
                {
                    delimiters.Add(delimiterString);
                }
                else
                {
                    var inDelimiter = false;
                    var builder = new StringBuilder();
                    foreach (var delimiterChar in delimiterString)
                    {
                        if (delimiterChar == '[')
                        {
                            inDelimiter = true;
                        }
                        else if (inDelimiter)
                        {
                            if (delimiterChar == ']')
                            {
                                delimiters.Add(builder.ToString());
                                builder.Clear();
                                inDelimiter = false;
                            }
                            else
                            {
                                builder.Append(delimiterChar);
                            }
                        }
                    }
                }
                workingNumbers = string.Join("\n", delimiterParts.Skip(1));
            }
            return workingNumbers;
        }

        private static int Add(string workingNumbers, List<string> delimiters)
        {
            var total = 0;
            var parts = workingNumbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            var negatives = new List<int>();
            foreach (var part in parts.Where(p => p.Length > 0))
            {
                var number = int.Parse(part);
                if (number < 0)
                {
                    negatives.Add(number);
                }
                if (number <= 1000) total += number;
            }
            if (negatives.Any()) throw new ArgumentException($"Negatives not allowed : {string.Join(", ", negatives)}");
            return total;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            List<string> delimiters = new List<string>{ "\n" };
            if (numbers.StartsWith("//"))
            {
                int index = 2;
                if (numbers[index] == '[')
                {
                    var delimiter = string.Empty;
                    while(numbers[index] == '[')
                    {
                        index = GetMultiSignDelimiter(numbers,out delimiter,index) + 1 ;
                        delimiters.Add(delimiter);
                    }

                    numbers = numbers.Substring(index + 1);
                }
                else
                {
                    delimiters.Add(numbers[index].ToString());
                    numbers = numbers.Substring(index+2);
                }
            }
            else
            {
                delimiters.Add(",");
            }

            var splitted = numbers.Split(delimiters.ToArray() ,StringSplitOptions.RemoveEmptyEntries);
            

            var parsedNumbers = splitted.Select(ParseInt).ToList();

            var negativeNumbers = parsedNumbers.Where(n => n < 0).ToList();

            return negativeNumbers.Any()
                ? throw new ArgumentException($"negatives not allowed: {string.Join(", ", negativeNumbers)}")
                : parsedNumbers.Where(n => n < 1000).Sum();
        }

        private int GetMultiSignDelimiter(string numbers, out string delimiter, int oldIndex)
        {
            delimiter = String.Empty;

            var index = oldIndex + 1;
            for (; numbers[index] != ']'; index++)
                delimiter += numbers[index];

            return index;
        }

        private int ParseInt(string number)
        {
            return int.Parse(number);
        }

    }
}

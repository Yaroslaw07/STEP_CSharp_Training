using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{


    class WorkWithConsole
    {

        public static int GetOperation()
        {
            Console.WriteLine("Select operation\n" +
                "1 - Add\n" +
                "2 - Minus\n" +
                "3 - Multiply\n" +
                "4 - Division\n");
            int numbOfOperation = int.Parse(Console.ReadLine());
            while(numbOfOperation < 1 || numbOfOperation > 4)
            {
                Console.WriteLine("Wrong operation. Select another");
                numbOfOperation = int.Parse(Console.ReadLine());
            }
            return numbOfOperation;
        }

        public static double GetDigit(string message = "") 
        {
            double numb;
            Console.WriteLine($"Put a {message} digit");
            string strCheck = Console.ReadLine();
            while (!double.TryParse(strCheck,out numb))
            {
                Console.WriteLine("It is not a digit\n" +
                    "Please enter another");

                strCheck = Console.ReadLine();
            }
            return numb;
        }
            
        public static void SetResult(double result)
        {
            Console.WriteLine("Result: " + result);
        }
    }
}

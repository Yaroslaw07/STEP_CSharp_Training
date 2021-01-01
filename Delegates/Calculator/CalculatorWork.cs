using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class CalculatorWork
    {
        public static void Calculate()
        {
            int operation = WorkWithConsole.GetOperation();
            Func<double, double, double> func = SetFunc(operation);
            WorkWithConsole.SetResult(func(
                WorkWithConsole.GetDigit("first"),
                WorkWithConsole.GetDigit("second")));
        }


        public static Func<double,double,double> SetFunc(int operation)
        {
            Func<double, double, double> a = MathOperations.Add;
            switch(operation)
            {
                case 2:
                    a = MathOperations.Minus;
                    break;
                case 3:
                    a = MathOperations.Multiply;
                    break;
                case 4:
                    a = MathOperations.Division;
                    break;
            }
            return a;
        }
    }
}

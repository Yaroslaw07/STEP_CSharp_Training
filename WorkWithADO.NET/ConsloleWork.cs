using System;
using System.Collections.Generic;
using System.Text;

namespace WorkWithADO.NET
{
    class ConsoleWork
    {
        public void Output<T>(string message, List<T> list)
        {
            Console.WriteLine(message);
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
            Console.Write("\n");
        }     

        public void Output<T>(string message, T value)
        {
            Console.WriteLine(message + " " + value+ "\n");
        }
    }
}

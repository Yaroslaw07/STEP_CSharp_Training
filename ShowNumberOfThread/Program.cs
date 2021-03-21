using System;
using System.Threading;

namespace ShowNumberByThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a digit from 1 to 7: ");
            int numbOfShow = int.Parse(Console.ReadLine());

            while(numbOfShow <= 0 || numbOfShow >7)
            {
                Console.WriteLine("Wrong number. Try again:");
                numbOfShow = int.Parse(Console.ReadLine());
            }

            for (int i = 1; i <= numbOfShow; i++)
            {
                Thread t = new Thread(PrintNumber);
                t.Start(i);
            }

            Thread.Sleep(1000);
        }

        public static void PrintNumber(object numb)
        {
            int numbToShow = (int)numb;
            for (int i = 0; i < 100; i++)
            {
                string tab = string.Empty;
                for (int j = 1; j < numbToShow; j++)
                {
                    tab += "\t";
                }
                string res = tab + numbToShow;
                Console.WriteLine(res);
            }
        }
    }
}

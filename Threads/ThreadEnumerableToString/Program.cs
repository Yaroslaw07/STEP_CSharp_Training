using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThreadEnumerableToString
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> list = new List<char> { 'd', 'a', '2', '5', '3'};

            Task task = new Task(() => ThreadEnumerableToString(list));

            task.Start();

            task.Wait();
        }


        public static void ThreadEnumerableToString<T>(IEnumerable<T> list)
        {
            foreach (T item in list)
            {
                Console.Write(item.ToString()+" ");
            }
        }
    }
}
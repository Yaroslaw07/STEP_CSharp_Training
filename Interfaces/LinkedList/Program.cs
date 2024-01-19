using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>{ 1, 3, 5, 2, 7 };
            LinkedList<int> list2 = list.Reverse();


            list2.RemoveAt(2);
            list2.Insert(4,14);
            foreach (int elem in list2)
            {
                Console.WriteLine(elem);
            }
        }
    }
}

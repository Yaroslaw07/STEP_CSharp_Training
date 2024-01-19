using System;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Doubly_LinkedList<int> list = new Doubly_LinkedList<int>(25);
            list.Add(21);
            list.Add(1);
            Console.WriteLine(list.Contains(21));
        }
    }
}

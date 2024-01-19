using System;

namespace _Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Add(12);
            stack.Push(53);
            stack.Add(11);
            stack = stack.Reverse();
            stack.Pop();
            stack.Remove(53);
            stack.Push(13);
            Console.WriteLine(stack.Top());
        }
    }
}

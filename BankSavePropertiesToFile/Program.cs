using System;
using System.Threading;


namespace BankSavePropertiesToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank A = new Bank();
            A.money = 40;
            Thread.Sleep(100);

            A.name = "ffad";
            Thread.Sleep(100);

            A.percent = 12;
            Thread.Sleep(100);
        }
    }
}
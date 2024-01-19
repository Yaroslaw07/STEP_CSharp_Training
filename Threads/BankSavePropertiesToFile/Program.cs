using System;
using System.Threading;


namespace BankSavePropertiesToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank A = new Bank(12,"323",34);
            
            A.money = 40;

            A.name = "ffad";

            A.percent = 12;
            Thread.Sleep(100);
        }
    }
}
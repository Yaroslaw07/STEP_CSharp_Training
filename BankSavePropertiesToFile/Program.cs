using System;
using System.Threading;
using System.IO;

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

    class Bank
    {
        private int Money;
        private string Name;
        private int Percent;
        public int money
        {
            get
            {
                return Money;
            }
            set
            {
                Money = value;
                ThreadPool.QueueUserWorkItem(SaveToFile);
            }
        }
        public string name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
                ThreadPool.QueueUserWorkItem(SaveToFile);
            }
        }

        public int percent
        {
            get
            {
                return Percent;
            }
            set
            {
                Percent = value;
                ThreadPool.QueueUserWorkItem(SaveToFile);
            }
        }

        public Bank()
        {

        }

        private void SaveToFile(object StateInfo)
        {
            File.WriteAllText("file1.txt",GetStringOfProperties());
        }


        private string GetStringOfProperties()
        {
            var props = GetType().GetProperties();
            string result = GetType().Name;
            result += ": ";

            foreach (var property in props)
            {
                result += $"{property.Name} = {property.GetValue(this)} | ";
            }
            return result;
        }

    }
}
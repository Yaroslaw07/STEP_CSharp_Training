﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;

namespace BankSavePropertiesToFile
{
    class Bank
    {
        private int Money;
        private string Name;
        private int Percent;

        private string path;
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
            path = "file1.txt";
        }

        public Bank(int Money, string Name, int Percent,string Path = "file1.txt")
        {
            money = Money;
            name = Name;
            percent = Percent;
            path = Path;
        }

        private void SaveToFile(object StateInfo)
        {
            lock (path)
            {
                File.WriteAllText(path, GetStringOfProperties());
            }
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

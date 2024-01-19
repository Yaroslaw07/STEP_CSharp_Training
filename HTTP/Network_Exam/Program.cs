using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;


namespace Network_Exam
{

    internal class Program
    {
        
 
        static void Main(string[] args)
        {
            string comm = string.Empty;
            while (comm != "exit")
            {
                Console.Write("command: ");
                comm = Console.ReadLine();
                switch (comm)
                {
                    case "check urls":
                        {
                            int length = 0, tryCount = 0;
                            while (length == 0)
                            {
                                Console.WriteLine("Enter size: ");
                                try
                                {
                                    length = int.Parse(Console.ReadLine());
                                    if (length <= 0 || length > 10)
                                        throw new Exception();
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Wrong input type");
                                }
                                catch
                                {
                                    Console.WriteLine("Wrong size");
                                    length = 0;
                                }

                                tryCount++;
                                if (tryCount == 4)
                                {
                                    Console.WriteLine("You get the max count of try. You will be returned to choosing command\n");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Please write again");
                                }
                            }

                            List<string> urls = new List<string>();

                            for (int i = 1; i <= length; i++)
                            {
                                Console.WriteLine("Enter " + i + " url: ");
                                urls.Add(Console.ReadLine());
                            }

                            CheckUrls(urls);
                            
                            break;
                        }

                    case "check s_urls":
                    {
                        Console.WriteLine("Enter a string: ");
                        string surl = Console.ReadLine();
                        var urls = surl.Split(",").ToList();

                        CheckUrls(urls);

                        break;
                    }

                    case "help":
                    {
                        help_menu();
                        break;
                    }

                    case "exit": break;

                    default:
                    {
                        Console.WriteLine("Type \"help\" to see support commands");
                        break;
                    }
                }
            }

        }

        private static void help_menu()
        {
            Console.WriteLine("Support commands: ");
            Console.WriteLine("\"check urls\" - to check urls entering one by one after input the size");
            Console.WriteLine("\"check s_urls\" - to check urls entering a string with split by \',\'");
            Console.WriteLine("\"exit\" - to close program");
        }

        public static  void CheckUrls(List<string> urls)
        {
            Checker checker = new Checker(urls);
            checker.CheckUrls();

            ResultHandler result = new ResultHandler(checker.result);
            result.ShowAll();
        }
    }
}

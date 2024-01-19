using Games_Report__CodeFirst_.Entities;
using System;
using System.Collections.Generic;

namespace Games_Report__CodeFirst_
{
    class Program
    {
        static void Main(string[] args)
        {
            GameInfoService service = new GameInfoService();

           
            int choose = 1;
            while (choose != 5)
            {
                Console.WriteLine("Выберите операцию\n1-Информации о всех играх\n2-Информации о невышедших играх\n3-Информации об играх определенного стиля\n4-Информации об играх определенной студии\n5-Выйти");
                choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        {
                            List<GameInfo> listOfGames = (List<GameInfo>)service.Get();
                            OutputListOfGames(listOfGames);
                            break;
                        }

                    case 2:
                        {
                            List<GameInfo> listOfGames = (List<GameInfo>)service.GetGamesAfterDate(DateTime.Now);
                            OutputListOfGames(listOfGames);
                            break;
                        }

                    case 3:
                        {
                            Console.WriteLine("Напишите жанр игры");
                            string theme = Console.ReadLine();
                            List<GameInfo> listOfGames = (List<GameInfo>)service.GetGamesSomeStyle(theme);
                            OutputListOfGames(listOfGames);
                            break;
                        }

                    case 4:
                        {
                            Console.WriteLine("Напишите создателя игры");
                            string creator = Console.ReadLine();
                            List<GameInfo> listOfGames = (List<GameInfo>)service.GetGamesSomeCreator(creator);
                            OutputListOfGames(listOfGames);
                            break;
                        }

                }


            }
            
           
        }



        public static void OutputListOfGames(List<GameInfo> listOfGames)
        {
            if (listOfGames.Count > 0)
            {
                foreach (GameInfo item in listOfGames)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
                Console.WriteLine("В базе данных таких игр не существует");
        }
    }
}

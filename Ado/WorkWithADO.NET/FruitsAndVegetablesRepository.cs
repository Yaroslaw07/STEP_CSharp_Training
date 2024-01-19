using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WorkWithADO.NET
{
    public class FruitsAndVegetablesRepository
    {
        private readonly SqlConnection _connection;
        private readonly string _tableName = "FruitsAndVegetables";


        public FruitsAndVegetablesRepository()
        {
            var connectionString = @"Data Source = PC; Initial Catalog = WorkWithC#;Integrated Security=True;";
            _connection = new SqlConnection(connectionString);
            try
            {
                _connection.Open();
                Console.WriteLine("База данных успешно подключена");
            }
            catch(Exception)
            {
                Console.WriteLine("Не получилось подключиться к базе данных");
            }
        }

        public List<Food> GetAllFruitsAndVegetables()
        {
            var commandText = $"SELECT * FROM {_tableName}";
            var command = GetCommand(commandText);

            using var FoodReader = command.ExecuteReader();
            List<Food> list = new List<Food>();
            while (FoodReader.Read())
            {
                list.Add(new Food((int)FoodReader[0], 
                                  (string)FoodReader[1], 
                                  (string)FoodReader[2], 
                                  (string)FoodReader[3], 
                                  (decimal)FoodReader[4]));               
            }

            return list;
        }

        public List<string> GetAllFromColumn(string columnName)
        {
            var commandText = "SELECT DISTINCT "+ columnName + $" FROM {_tableName}";
            var command = GetCommand(commandText);
            
            List<string> res = new List<string>();

            using var FoodReader = command.ExecuteReader();
            while (FoodReader.Read())
            {
                res.Add(FoodReader[0].ToString());

            }

            return res;
        }

        public decimal GetMaxCalorificValue()
        {
            var commandText = $"SELECT MAX(CalorificValue) FROM {_tableName}";
            var command = GetCommand(commandText);

            using var FoodReader = command.ExecuteReader();
            FoodReader.Read();

            return (decimal)FoodReader[0];
        }

        public decimal GetMinCalorificValue()
        {
            var commandText = $"SELECT MIN(CalorificValue) FROM {_tableName}";
            var command = GetCommand(commandText);

            using var FoodReader = command.ExecuteReader();
            FoodReader.Read();

            return (decimal)FoodReader[0];
        }

        public decimal GetAVGCalorificValue()
        {
            var commandText = $"SELECT AVG(CalorificValue) FROM {_tableName}";
            var command = GetCommand(commandText);

            using var FoodReader = command.ExecuteReader();
            FoodReader.Read();

            return (decimal)FoodReader[0];
        }

        public int GetCountByType(string Type)
        {
            var commandText = $"SELECT COUNT(DISTINCT Name) FROM {_tableName} WHERE Type = @type";
            var command = GetCommand(commandText);
            command.Parameters.AddWithValue("type", Type);

            using var FoodReader = command.ExecuteReader();
            FoodReader.Read();

            return (int)FoodReader[0];
        }

        public int GetCountByColor(string Color)
        {
            var commandText = $"SELECT COUNT(DISTINCT Name) FROM {_tableName} WHERE Color = @color";
            var command = GetCommand(commandText);
            command.Parameters.AddWithValue("color", Color);

            using var FoodReader = command.ExecuteReader();
            FoodReader.Read();

            return (int)FoodReader[0];
        }



        public List<ColorStatisticItem> StatisticByColor()
        {
            var commandText = $"SELECT Color , COUNT(Name) FROM {_tableName} GROUP BY Color";
            var command = GetCommand(commandText);

            using var FoodReader = command.ExecuteReader();
            List<ColorStatisticItem> result = new List<ColorStatisticItem>();
            ColorStatisticItem item;
            while (FoodReader.Read())
            {
                item.NameColor = (string)FoodReader[0];
                item.Count = (int) FoodReader[1];
                result.Add(item);
            }

            return result;

        }

        public List<Food> SelectWithMaxCalority(int maxCalority)
        {
            var commandText = $"SELECT * FROM {_tableName} WHERE CalorificValue > @max";
            var command = GetCommand(commandText);
            command.Parameters.AddWithValue("max", maxCalority);

            using var FoodReader = command.ExecuteReader();
            List<Food> list = new List<Food>();
            while (FoodReader.Read())
            {
                list.Add(new Food((int)FoodReader[0],
                                  (string)FoodReader[1],
                                  (string)FoodReader[2],
                                  (string)FoodReader[3],
                                  (decimal)FoodReader[4]));

            }

            return list;
        }

        public List<Food> SelectWithMinCalority(int minCalority)
        {
            var commandText = $"SELECT * FROM {_tableName} WHERE CalorificValue < @min";
            var command = GetCommand(commandText);
            command.Parameters.AddWithValue("min", minCalority);

            using var FoodReader = command.ExecuteReader();
            List<Food> list = new List<Food>();
            while (FoodReader.Read())
            {
                list.Add(new Food((int)FoodReader[0],
                                  (string)FoodReader[1],
                                  (string)FoodReader[2],
                                  (string)FoodReader[3],
                                  (decimal)FoodReader[4]));

            }

            return list;
        }

        public List<Food> FoodFromCalorificDiapazon(int min, int max)
        {
            var commandText = $"SELECT * FROM {_tableName} WHERE CalorificValue > @min and CalorificValue < @max";
            var command = GetCommand(commandText);
            command.Parameters.AddWithValue("min", min);
            command.Parameters.AddWithValue("max", max);

            using var FoodReader = command.ExecuteReader();
            List<Food> list = new List<Food>();
            while (FoodReader.Read())
            {
                list.Add(new Food((int)FoodReader[0],
                                  (string)FoodReader[1],
                                  (string)FoodReader[2],
                                  (string)FoodReader[3],
                                  (decimal)FoodReader[4]));

            }

            return list;
        }

        public List<Food> FoodByColor(string color1,string color2)
        {
            var commandText = $"SELECT * FROM {_tableName} WHERE Color = @color1 or Color = @color2";
            var command = GetCommand(commandText);
            command.Parameters.AddWithValue("color1", color1);
            command.Parameters.AddWithValue("color2", color2);

            using var FoodReader = command.ExecuteReader();
            List<Food> list = new List<Food>();
            while (FoodReader.Read())
            {
                list.Add(new Food((int)FoodReader[0],
                                  (string)FoodReader[1],
                                  (string)FoodReader[2],
                                  (string)FoodReader[3],
                                  (decimal)FoodReader[4]));

            }

            return list;
        }

        private SqlCommand GetCommand(string command)
        {
            return new SqlCommand(command, _connection);
        }
    }
}

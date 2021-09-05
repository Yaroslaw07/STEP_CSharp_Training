using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkWithADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            FruitsAndVegetablesRepository repository = new FruitsAndVegetablesRepository();
            ConsoleWork console = new ConsoleWork();

            List<Food> food = repository.GetAllFruitsAndVegetables();
            console.Output("Список всей еды: ", food);

            List<string> allNames = repository.GetAllFromColumn("Name");

            console.Output("Все название товаров: ", allNames);

            List<string> allColors = repository.GetAllFromColumn("Color");
            console.Output("Все цвета товаров: ", allColors);

            decimal maxCalor = repository.GetMaxCalorificValue();
            console.Output("Максимальная калорийность:", maxCalor);

            decimal minCalor = repository.GetMinCalorificValue();
            console.Output("Минимальная калорийность:", minCalor);

            decimal avgCalor = repository.GetAVGCalorificValue();
            console.Output("Средняя калорийность:", avgCalor);

            int countVegetables = repository.GetCountByType("Vegetable");
            console.Output("Количество овощей:", countVegetables);

            int countFruits = repository.GetCountByType("Fruit");
            console.Output("Количество фруктов:", countFruits);

            int countRed = repository.GetCountByColor("Red");
            console.Output("Все продукты красного цвета:", countRed);

            List<ColorStatisticItem> statisticByColors = repository.StatisticByColor();
            console.Output("Статистика по цветам:", statisticByColors);

            List<Food> higherSomeCalority = repository.SelectWithMaxCalority(149);
            console.Output("Продукты выше калорийности 149:", higherSomeCalority);

            List<Food> lowerSomeCalority = repository.SelectWithMinCalority(149);
            console.Output("Продукты ниже калорийности 149:", lowerSomeCalority);

            List<Food> calorityFromDiapazon = repository.FoodFromCalorificDiapazon(100, 200);
            console.Output("Продукты в промежутке калорийности от 100 до 200:", calorityFromDiapazon);

            List<Food> onlyYellowAndRedProducts = repository.FoodByColor("Red","Yellow");
            console.Output("Продукты красного и желтого цвета:", onlyYellowAndRedProducts);
        }


    }
}
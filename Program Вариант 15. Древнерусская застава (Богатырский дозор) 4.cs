using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Program4
{
    internal class Program
    {
        static void Main()
        {
            // Объявляем массив снаряжения
            string[] gear = {
                "Булатный меч",
                "Кованый щит",
                "Колчан калёных стрел",
                "Горбушка хлеба",
                "Шёлковый шатёр"
            };

            Console.WriteLine("=== Снаряжение богатырского дозора ===");

            // Правильный цикл foreach: указываем массив и убираем лишнюю точку с запятой
            foreach (string item in gear)
            {
                Console.WriteLine($"  • {item}");
            }
        }
    }
}
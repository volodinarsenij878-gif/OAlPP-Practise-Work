using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Объявляем массив снаряжения богатырского дозора
            string[] gear = {
                "Булатный меч",
                "Кованый щит",
                "Колчан калёных стрел",
                "Горбушка хлеба",
                "Шёлковый шатёр"
            };

            // 2. Ищем индекс «Кованый щит» в массиве
            int shieldIndex = Array.IndexOf(gear, "Кованый щит");

            // 3. Проверяем результат и выводим сообщение
            if (shieldIndex != -1)
            {
                Console.WriteLine("--- ПОДГОТОВКА К ЗАЛПУ ---");
                Console.WriteLine($"Кованый щит найден в слоте №{shieldIndex} — готов к отражению залпа.\n");
            }
            else
            {
                Console.WriteLine("Ошибка: Кованый щит не найден в снаряжении!\n");
            }
        }
    }
}
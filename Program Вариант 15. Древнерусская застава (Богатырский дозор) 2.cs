using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    internal class Program
    {
        static void Main()
        {
            string[] enemyRanks = { "Степной дозорный", "Лесной разбойник", "Степной хан" };
            int[] warriorsInHundred = { 1, 3, 7 };          // пример: сколько сотен примерно соответствует силе врага
            int[] battleFury = { 40, 60, 90 };           // уровень ярости/агрессии

            Console.WriteLine("Супостаты на рубеже:");
            for (int i = 0; i < enemyRanks.Length; i++)
            {
                Console.WriteLine($"{enemyRanks[i]} | Сотен: {warriorsInHundred[i]} | Ярость: {battleFury[i]}");
            }
            Console.WriteLine();
        }
    }
}
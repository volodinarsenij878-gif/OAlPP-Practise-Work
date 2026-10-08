using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] equipment = new string[5];
            equipment[0] = "Булатный меч";
            equipment[1] = "Кованый щит";
            equipment[2] = "Колчан калёных стрел";
            equipment[3] = "Горбушка хлеба";
            equipment[4] = "Шёлковый шатёр";

            // Вывод перечня снаряжения через цикл foreach
            Console.WriteLine("Снаряжение богатырского дозора:");
            foreach (var item in equipment)
            {
                Console.WriteLine("- " + item);
            }
            Console.WriteLine();
        }
    }
}

                
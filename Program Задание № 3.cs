using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите температуру в градусах Цельсия: ");

            double celsius = double.Parse(Console.ReadLine());

            double fahrenheit = celsius * 9.0 / 5.0 + 32.0;

            Console.WriteLine($"Температура в градусах Фаренгейта: {fahrenheit}");
        }
    }
}


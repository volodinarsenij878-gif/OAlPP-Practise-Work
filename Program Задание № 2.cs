using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write(value: "Введите первое целое число: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите второе целое число: ");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine($"Сумма: {a + b}");
            Console.WriteLine($"Разность: {a - b}");
            Console.WriteLine($"Произведение: {a * b}");
            Console.WriteLine($"Целочисленное частное: {a / b}");
            Console.WriteLine($"Остаток от деления: {a % b}");
        }
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите a: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Введите b: ");
            int b = int.Parse(Console.ReadLine());

            // Сохраняем исходные значения
            int originalA = a;
            int originalB = b;

            // Обмен с третьей переменной
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine($"Обмен с третьей переменной: a = {a},b = {b}");

            // Возвращаем исходные значения
            a = originalA;
            b = originalB;

            // Арифметический обмен
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine($"Арифметический обмен: a = {a}, b = {b}");
        }
    }
}
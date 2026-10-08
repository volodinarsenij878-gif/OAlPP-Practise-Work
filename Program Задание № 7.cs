using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Program7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите первое число: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Введите второе число: ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("Введите третье число: ");
            double c = double.Parse(Console.ReadLine());

            double average = (a + b + c) / 3.0;

            Console.WriteLine($"Среднее арифметическое: {average}");
        }
    }
}

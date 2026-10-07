using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите длину ребра куба: ");
            double edge = double.Parse(Console.ReadLine());

            double volume = edge * edge * edge;
            double surface = 6 * edge * edge;

            Console.WriteLine($"Объем куба: {volume:F2}");
            Console.WriteLine($"Площадь полной поверхности: {surface:F2}");
        }
    }
}
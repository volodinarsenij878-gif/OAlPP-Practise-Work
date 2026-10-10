using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program32
{
    internal class Program
    {
        static void Main()
        {
            int a = 5;  // 0101
            int b = 3;  // 0011

            int orRes = a | b;  // 0111 → 7

            // Форматируем до 4 бит с ведущими нулями
            string binA = Convert.ToString(a, 2).PadLeft(4, '0');
            string binB = Convert.ToString(b, 2).PadLeft(4, '0');
            string binRes = Convert.ToString(orRes, 2).PadLeft(4, '0');

            Console.WriteLine($"A = {a} → {binA}");
            Console.WriteLine($"B = {b} → {binB}");
            Console.WriteLine("-------------------------");
            Console.WriteLine($"| (ИЛИ): {binA} | {binB} = {binRes}");
            Console.WriteLine($"Результат в десятичном виде: {orRes}");
        }
    }
}

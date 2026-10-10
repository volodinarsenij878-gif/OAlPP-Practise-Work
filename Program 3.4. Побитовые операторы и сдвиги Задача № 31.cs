using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program31
{
    internal class Program
    {
        static void Main() 
        {
            int a = 5;  // 0101
            int b = 3;  // 0011

            int res = a & b;  // 0001 → 1

            // Преобразуем в двоичную строку и дополняем слева нулями до 4 символов
            string binA = Convert.ToString(a, 2).PadLeft(4, '0');
            string binB = Convert.ToString(b, 2).PadLeft(4, '0');
            string binRes = Convert.ToString(res, 2).PadLeft(4, '0');

            Console.WriteLine($"A = {a} → двоичное: {binA}");
            Console.WriteLine($"B = {b} → двоичное: {binB}");
            Console.WriteLine("-------------------------");
            Console.WriteLine($"A & B → {binA} & {binB} = {binRes}");
            Console.WriteLine($"Результат в десятичном виде: {res}");
        }
    }
}

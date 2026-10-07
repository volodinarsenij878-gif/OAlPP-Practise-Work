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
            Console.Write("Введите фамилию: ");
            string lastName = Console.ReadLine() ?? "";

            Console.Write("Введите имя: ");
            string firstName = Console.ReadLine() ?? "";

            Console.Write("Введите отчество:  ");
            string patronymic = Console.ReadLine() ?? "";

            string result = $"{lastName} {firstName[0]}. {patronymic[0]}.";
            Console.WriteLine(result);
        }
    }
}

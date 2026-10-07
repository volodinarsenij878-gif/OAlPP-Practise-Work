    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Program37
    {
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 42;
            object boxed = x; // упаковка (boxing)

            // Распаковка в исходный тип int
            int unboxed = (int)boxed;
            Console.WriteLine($"Распаковка в int: {unboxed}");

            try
            {
                // Правильно: сначала распаковываем в int, затем приводим к short
                short sGood = (short)(int)boxed;
                Console.WriteLine($"Приведение к short: {sGood}");
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Program30
    {
    class Program
    {
        static void Main()
        {
            bool[] values = { true, false };

            Console.WriteLine("Проверка !(A || B) == (!A && !B):\n");

            foreach (var A in values)
            {
                foreach (var B in values)
                {
                    bool left = !(A || B);
                    bool right = !A && !B;
                    bool same = left == right;

                    Console.WriteLine(
                        $"A={A}, B={B} → !(A||B)={left}, (!A&&!B)={right} → совпадают? {same}");
                }
            }
        }
    }
    }

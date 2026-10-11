using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program75
{
    internal class Program
    {
        static void Main()
        {
            bool result = (8 > 5) && (3 + 2 * 4 == 11) && !(false || !true);
            Console.WriteLine(result); // True
        }
    }
}

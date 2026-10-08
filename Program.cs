using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string targetItem = "Кованый щит";
            int shieldIndex = Array.IndexOf(equipment, targetItem);

            if (shieldIndex != -1)
            {
                Console.WriteLine($"Перед залпом найден «{targetItem}» в слоте №{shieldIndex} (индекс). Готов к отражению удара!\n");
            }
            else
            {
                Console.WriteLine($"Предмет «{targetItem}» не найден в снаряжении!\n");
            }
        }
    }
}
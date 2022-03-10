using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class ForestMenu
    {
        public ForestMenu()
        {
            ShowMenu();
        }

        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------");
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("l");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Look for something to Kill!");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("R");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Return to Town!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------------");
        }
    }
}

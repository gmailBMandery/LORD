using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD
{
    class ForestMenu
    { 
        private bool stayInTheForest = false;

        public ForestMenu()
        {
            ShowMenu();
        }

        private void ShowMenu()
        {
            stayInTheForest = true;
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------");
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("L");
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

            string input = GatherInput.GetInput();
            switch(input.ToUpper())
            {
                case "L":
                    //Console.WriteLine("Hell yes, we are looking for shit to kill");
                    ForestFightingMenu forestFightingMenu = new ForestFightingMenu();
                    //Console.ReadKey();
                    break;

                case "R":
                    Console.WriteLine("Returning to town.");
                    stayInTheForest = false;
                    //Console.ReadKey();
                    break;

                default:
                    break;
            }

            if (stayInTheForest)
                ShowMenu();
        }
    }
}

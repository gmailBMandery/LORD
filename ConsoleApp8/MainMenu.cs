using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD
{
    internal class MainMenu
    {
        public void PaintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------");
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("F");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Enter the Forest!");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Q");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Leave This Realm!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------------");
        }

        Boolean keepRunning = true;
        public Boolean ProcessSelection(string input)
        {
            
            switch(input.ToUpper())
            {
                case "F":
                    Console.WriteLine("We're going to the forest");
                    Console.ReadKey();
                    ForestMenu forestMenu = new ForestMenu();
                    PaintMainMenu();
                    ProcessSelection(GatherInput.GetInput());
                    break;

                case "Q":
                    Console.WriteLine("Sorry to see you leave so soon");
                    Console.ReadKey();
                    keepRunning = false;
                    break;
                    
                default:
                    PaintMainMenu();
                    break;
            }

            return keepRunning;

        }
    }
}

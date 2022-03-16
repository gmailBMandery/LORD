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
            Console.WriteLine("ook for something to Kill!");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("H");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("ealer's Hut");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("R");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("eturn to Town");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------------");

            ConsoleKeyInfo keyInfo = GatherInput.GetKeyedInput();
            switch(keyInfo.Key)
            {
                case ConsoleKey.L:
                    //Console.WriteLine("Hell yes, we are looking for shit to kill");
                    ForestFightingMenu forestFightingMenu = new ForestFightingMenu();
                    break;

                case ConsoleKey.H:
                    //Show healers hut menu, for now just restore all hitpoints to the player.
                    HealersHutScreen hhs = new HealersHutScreen();
                    ShowMenu();
                    break;
                case ConsoleKey.R:
                    Console.WriteLine("Returning to town.");
                    stayInTheForest = false;
                    break;

                default:
                    break;
            }

            if (stayInTheForest)
                ShowMenu();
        }
    }
}

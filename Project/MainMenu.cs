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
            Console.Write("Legend Of The Red Dragon - ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Town Square");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The streets are crowded, it is difficult to");
            Console.WriteLine(" push your way through the mob...");
            Console.WriteLine();
            Console.WriteLine();

            //Forest
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("F");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Enter the Forest");

            //Slaughter of players
            Console.CursorLeft = 40;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("S");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("laughter other Players");




            //King Arthurs Weapons
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("K");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("ing Arthurs Weapons");


            //Abduls Armour
            Console.CursorLeft = 40;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("A");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("bduls Armour");

            //Healers Hut
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("H");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("ealers Hut");

            //View your status
            Console.CursorLeft = 40;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("V");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("iew your stats");

            //Inn
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("I");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("nn");

            //Ye old Bank
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Y");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("e Old Bank");


            //Quit to the Fields
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Q");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Leave This Realm");
            
        }

        Boolean keepRunning = true;
        public Boolean ProcessSelection(ConsoleKeyInfo keyInfo)
        {
            
            switch(keyInfo.Key)
            {
                case ConsoleKey.F:
                    ForestMenu forestMenu = new ForestMenu();
                    PaintMainMenu();
                    ProcessSelection(GatherInput.GetKeyedInput());
                    break;

                case ConsoleKey.V:
                    PlayerStatsScreen ps = new PlayerStatsScreen();
                    PaintMainMenu();
                    ProcessSelection(GatherInput.GetKeyedInput());
                    break;
                case ConsoleKey.Q:
                    Console.WriteLine();
                    Console.WriteLine();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD
{
    class HealersHutScreen
    {
        public HealersHutScreen()
        {
            if(Program.player.HitPoints==Program.player.MaxHitPoints)
            {
                Console.Clear();
                Console.CursorLeft = 2;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You appear to be in perfect heath, nothing we can do for you at this time.");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press anykey to continue");
                Console.ReadKey();
                return;
            }

            DisplayMenu();
        }

        private void DisplayMenu()
        {
            Console.Clear();
            Console.CursorLeft = 2;
            Console.Write("Legend of the Red Dragon - ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Healers");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorLeft = 4;
            Console.WriteLine("You enter the smokey healers hut.");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.CursorLeft = 4;
            Console.Write("\"What is your wish, warrior?\"");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" the old healer asks.");
            Console.WriteLine();
            Console.WriteLine();

            Console.CursorLeft = 4;
            Console.Write("(");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("H");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(")eal all possible");

            Console.CursorLeft = 4;
            Console.Write("(");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("C");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(")ertain amount healed");

            Console.CursorLeft = 4;
            Console.Write("(");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("R");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(")eturn");

            Console.WriteLine();
            Console.WriteLine();

            Console.CursorLeft = 4;
            Console.WriteLine($"HitPoints: ({ Program.player.HitPoints} of {Program.player.MaxHitPoints})   Gold:   {Program.player.Gold}");
            Console.CursorLeft = 4;
            Console.WriteLine("(it const 10 to heal 1 hitpoint)");

            ProcessInput(GatherInput.GetKeyedInput());
        }

        private void ProcessInput(ConsoleKeyInfo consoleKeyInfo)
        {
            switch(consoleKeyInfo.Key)
            {
                //Heal all possible
                case ConsoleKey.H:
                    Console.Clear();
                    Console.CursorLeft = 4;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("All possible healing is done, you're feeling much better now");
                    Console.ReadKey();
                    break;

                //Certian amount only
                case ConsoleKey.C:
                    break;

                //Return
                case ConsoleKey.R:
                    break;
            }
        }
    }
}

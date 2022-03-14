using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD
{
    class PlayerStatsScreen
    {
        private Player player = Program.player;

        public PlayerStatsScreen()
        {
            Console.Clear();
            Console.CursorLeft = 3;
            Console.Write(player.Name.ToUpper());
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("'s Stats...");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.CursorLeft = 2;
            Console.Write("Experience");
            Console.CursorLeft = 15;
            Console.Write(" : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(player.ExperiencePoints);


            Console.Write("<MORE>");
            Console.ReadKey();

        }
    }
}

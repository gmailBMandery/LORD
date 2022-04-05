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
            Console.CursorLeft = 2;
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

            //Level
            Console.CursorLeft = 2;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Level");
            Console.CursorLeft = 15;
            Console.Write(" : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{player.Level}");

            //Hit points
            Console.CursorLeft = 35;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("HitPoints");
            Console.CursorLeft = 56;
            Console.Write($" : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{player.HitPoints} of {player.MaxHitPoints}");


            //Forest Fights
            Console.CursorLeft = 2;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Forest Fights");
            Console.CursorLeft = 15;
            Console.Write($" : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{player.ForestFights}");

            //Player Fights
            Console.CursorLeft = 35;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Player Fights Lefts");
            Console.CursorLeft = 56;
            Console.Write($" : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{player.PlayerFights}");

            //Gold in hand
            Console.CursorLeft = 2;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Gold In Hand");
            Console.CursorLeft = 15;
            Console.Write(" : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{player.Gold}");

            //Gold in bank
            Console.CursorLeft = 35;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Gold In Bank");
            Console.CursorLeft = 56;
            Console.Write($" : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{player.GoldInBank}");

            //Weapon in Hand
            Console.CursorLeft = 2;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Weapon");
            Console.CursorLeft = 15;
            Console.Write(" : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{Weapon.CreateWeapon((Weapons.WeaponIDs)player.WeaponType).Name.ToUpper()}");


            //Attack Strength
            Console.CursorLeft = 35;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Attack Strength");
            Console.CursorLeft = 56;
            Console.Write($" : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{player.AttackStrength}");

            //Armour
            Console.CursorLeft = 2;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Armour");
            Console.CursorLeft = 15;
            Console.Write(" : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{Armour.CreateArmour((ArmourIDs)player.ArmourType).Name.ToUpper()}");

            //Defensive Strength
            Console.CursorLeft = 35;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Defensize Strength");
            Console.CursorLeft = 56;
            Console.Write($" : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{player.DefensiveStrength}");

            //Charm
            Console.CursorLeft = 2;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Charm");
            Console.CursorLeft = 15;
            Console.Write(" : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{player.Charm}");

            //Gems
            Console.CursorLeft = 35;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Gems");
            Console.CursorLeft = 56;
            Console.Write($" : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{player.Gems}");


            Console.WriteLine();
            Console.WriteLine();
            Console.Write("<MORE>");
            Console.ReadKey();

        }
    }
}

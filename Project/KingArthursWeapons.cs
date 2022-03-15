using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD
{
    class KingArthursWeapons
    {
        public KingArthursWeapons()
        {
            DisplayMenu();
        }

        private void DisplayMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
            Console.Write("▓▀ The Legend of the Red Dragon - ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" Weapons List");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("▀▓▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▓▀");
            Console.Write("▀");
            Console.CursorLeft = 5;
            Console.Write("Weapons");
            Console.CursorLeft = 50;
            Console.WriteLine("Price");
            Console.CursorLeft = 5;
            Console.WriteLine("1. Stick.............................................200");
            Console.CursorLeft = 5;
            Console.WriteLine("2. Dagger..........................................1,000");
            Console.CursorLeft = 5;
            Console.WriteLine("3. Short Sword.....................................3,000");
            Console.CursorLeft = 5;
            Console.WriteLine("4. Long Sword.....................................10,000");
            Console.CursorLeft = 5;
            Console.WriteLine("5. Huge Axe.......................................30,000");
            Console.CursorLeft = 5;
            Console.WriteLine("6. Bone Cruncher.................................100,000");
            Console.CursorLeft = 5;
            Console.WriteLine("7. Twin Swords...................................150,000");
            Console.CursorLeft = 5;
            Console.WriteLine("8. Power Axe.....................................200,000");
            Console.CursorLeft = 5;
            Console.WriteLine("9. Able's Sword..................................400,000");
            Console.CursorLeft = 4;
            Console.WriteLine("10. Wan's Weapon................................1,000,000");
            Console.CursorLeft = 4;
            Console.WriteLine("11. Spear of Gold...............................4,000,000");
            Console.CursorLeft = 4;
            Console.WriteLine("12. Crystal Shard..............................10,000,000");
            Console.CursorLeft = 4;
            Console.WriteLine("13. Niras's Teeth..............................40,000,000");
            Console.CursorLeft = 4;
            Console.WriteLine("14. Blood Sword...............................100,000,000");
            Console.CursorLeft = 4;
            Console.WriteLine("15. Death Sword...............................400,000,000");

            ProcessInput(GatherInput.GetInput());
        }

        private void ProcessInput(string input)
        {
            int weaponSelection = 0;
            Boolean goodInput = Int32.TryParse(input, out weaponSelection);
            if(!goodInput)
            {
                Console.WriteLine("I don't understand!");
                Console.Write("<more>");
                Console.ReadKey();
                DisplayMenu();
                return;
            }

            Weapon w = Weapon.CreateWeapon(weaponSelection);
            if(w.Cost<Program.player.Gold && Program.player.Weapon == null)
            {
                //Yes we can purchase this weapon
                Program.player.PurchaseWeapon(w);
            }
            else
            {
                Console.WriteLine($"You do not have enough gold to purchase {w.Name}. Come back when you have more gold.");
                Console.ReadKey();
            }

        }
    }
}

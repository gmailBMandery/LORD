using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD
{
    class HealersHutScreen
    {
        private int costPerHitPoint = 0;
        public HealersHutScreen()
        {
            costPerHitPoint = Program.player.Level * 3;
            if(Program.player.HitPoints==Program.player.MaxHitPoints)
            {
                Console.Clear();
                Console.CursorLeft = 2;
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.CursorLeft = 2;
                Console.WriteLine("Ok, let's have a lil' look here at'cha today. Hmm, that is interesting!");
                Console.CursorLeft = 2;
                Console.WriteLine($"Oh, well I didn't expect that. {Program.player.Name}, you didn't need to come see me today.");
                Console.CursorLeft = 2;
                Console.WriteLine("You appear to be in perfect health, I am sorry but nothing I can help you will at this time.");
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
            Console.CursorLeft = 2;
            Console.WriteLine("You enter the smokey healers hut.");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.CursorLeft = 2;
            Console.Write("\"What is your wish, warrior?\"");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" the old healer asks.");
            Console.WriteLine();
            Console.WriteLine();

            Console.CursorLeft = 3;
            Console.Write("(");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("H");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(")eal all possible");

            Console.CursorLeft = 3;
            Console.Write("(");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("C");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(")ertain amount healed");

            Console.CursorLeft = 3;
            Console.Write("(");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("R");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(")eturn");

            Console.WriteLine();

            Console.CursorLeft = 3;
            Console.WriteLine($"HitPoints: ({ Program.player.HitPoints} of {Program.player.MaxHitPoints})   Gold:   {Program.player.Gold}");
            Console.CursorLeft = 3;
            Console.WriteLine($"(it cost {costPerHitPoint} to heal 1 hitpoint)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

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
                    HealAllPossible();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("<more>");
                    Console.ReadKey();
                    break;

                //Certian amount only
                case ConsoleKey.C:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.CursorLeft = 2;
                    Console.Write("How many hit points to heal today>>");
                    int pointsToHeal = 0;
                    bool goodInput = Int32.TryParse(Console.ReadLine(), out pointsToHeal);
                    if(goodInput)
                    {
                        if ((pointsToHeal+Program.player.MaxHitPoints) > Program.player.MaxHitPoints)
                            pointsToHeal = (Program.player.MaxHitPoints-Program.player.HitPoints);

                        Program.player.HealHitPoints(pointsToHeal, (pointsToHeal * Program.player.Level));
                        if (Program.player.HitPoints == Program.player.MaxHitPoints)
                        {
                            Console.Clear();
                            Console.CursorLeft = 2;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("You slowly drink the elixure the elder has created for you, you wait patiently.......");
                            Console.CursorLeft = 5;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{pointsToHeal} hit points have been restored. You are feeling much better now.");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.CursorLeft = 2;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("That doesn't appear to be a number I recogzine, Sorry!");
                        Console.ReadKey();
                        DisplayMenu();
                    }
                    break;

                //Return
                case ConsoleKey.R:
                    break;
            }
        }

        private void HealAllPossible()
        {
            Console.Clear();
            Player p = Program.player;
            int hitPointsToHeal = (p.MaxHitPoints - p.HitPoints);
            int totalCost = costPerHitPoint * hitPointsToHeal;
            if (totalCost > p.Gold)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("You do not have enough gold to heal all");
            }
            else
            {
                p.HealHitPoints(hitPointsToHeal, totalCost);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.CursorLeft = 3;
                Console.WriteLine($"{hitPointsToHeal} hitpoints were restored. You feel much better now.");
            }
        }
    }
}

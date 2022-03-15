using System;
namespace LORD
{
    internal class ForestFightingMenu
    {
        private static Random rnd = new Random(DateTime.Now.Millisecond);
        public ForestFightingMenu()
        {
            //Randomly find an event
            //Events could be monsters, happenings, wishing wells, finding treasure, helping people, etc.
            //For now we will just focus on monsters
            //In the future, we will have monster pools based on level
            //Which will be held in a file within? or external so we can add monsters and happenings on the fly
            Random rnd = new Random(DateTime.Now.Millisecond);
            double rndEnvent = rnd.NextDouble();

            CreatureEncounter encounter = new CreatureEncounter(Program.player.Level);
            Enemy monster = encounter.GetEncounter();

            StartEncounter(monster);

        }

        private static void StartEncounter(Enemy monster)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Fight");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("**");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"You have encountered {monster.Name}");
            Console.WriteLine();
            Console.WriteLine("Based on your skills, you get to attack first");
            Console.WriteLine();
            Console.WriteLine($"Your Hitpoints : {Program.player.HitPoints}");
            Console.WriteLine($"{monster.Name}'s hit points : {monster.HP}");
            Console.WriteLine();

            DisplayMenu();

            ConsoleKeyInfo keyInfo = GatherInput.GetKeyedInput();
            
            ProcessInput(monster, keyInfo, rnd);
        }

        private static void ProcessInput(Enemy monster, ConsoleKeyInfo input, Random rnd)
        {
            switch (input.Key)
            {
                case ConsoleKey.A:
                    int damageAmount = Program.player.GetDamage();
                    Console.WriteLine();
                    Console.WriteLine($"You lash at the {monster.Name} and hit for {damageAmount}");
                    monster.TakeDamage(damageAmount);
                    if (monster.IsDead)
                    {
                        Console.WriteLine($"The {monster.Name} is dead!");
                        //The reward will be gold and experiance
                        Console.WriteLine("This is your reward, */*-/*-/-/-*/-*/-*");
                        Console.Write("Press anykey to continue");
                        Console.ReadKey();//If monster is not dead, he/she will hit and the process will repeat
                    }
                    else
                    {
                        Console.WriteLine($"The {monster.Name} is not dead!");
                        ContinueEncounter(monster);
                    }


                    break;

                case ConsoleKey.R:
                    Console.WriteLine("You run away,fleeing and screaming. Luckily now one was around to see that failure. You loose 50 experiance points");
                    Console.ReadKey();
                    break;

                case ConsoleKey.S:
                    Console.WriteLine("View Stats has yet to be implemented");
                    Console.ReadKey();
                    break;

                default:
                    break;
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("A");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("ttack!");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("S");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("tats!");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("R");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("un away scared!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------------------------------------------------------------");
        }

        private static void ContinueEncounter(Enemy monster)
        {
            if (Program.player.TakeDamage(monster.DamageOutput))
                Console.WriteLine($"{monster.Name} hits you back for {monster.DamageOutput}.");
            else
                Console.WriteLine($"{monster.Name} misses you completly.");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Your hit points {Program.player.HitPoints}");
            Console.WriteLine("**********************");
            Console.WriteLine($"{monster.Name} 's hit points {monster.HP}");
            DisplayMenu();
            ConsoleKeyInfo keyInfo = GatherInput.GetKeyedInput();
            ProcessInput(monster, keyInfo, rnd);

        }
    }
}
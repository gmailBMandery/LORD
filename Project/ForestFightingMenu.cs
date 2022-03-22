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
            Console.WriteLine("Based on your skills, you get to attack first");//Not sure what we will use to calculate this yet
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
            int damageAmount = 0;
            switch (input.Key)
            {
                case ConsoleKey.A:
                    //First we must roll to see if we can even hit the enemy
                    //This will be done with a d20
                    int canHit = DieRoll.D20(); // 20 is an auto Crit Hit
                    Boolean crit = false;
                    if (canHit >= monster.ArmourClass)
                    {
                        //Check for crit hit
                        crit = DieRoll.Crit();
                        damageAmount = Program.player.GetDamage(crit);

                        Console.WriteLine();
                        Console.WriteLine((crit == true ? "Critital Hit" : "")); ;
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
                            //Console.WriteLine($"The {monster.Name} is not dead!");
                            ContinueEncounter(monster);
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine($"You missed {monster.Name} completly!");
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

        private static void ContinueEncounter(Enemy monster)
        {
            
            if (Program.player.TakeDamage(monster.DamageOutput))
            {

                Console.Write($"{monster.Name} hits you back for ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{monster.DamageOutput}.");
                Console.ForegroundColor = ConsoleColor.Green;
            }
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

    }
}
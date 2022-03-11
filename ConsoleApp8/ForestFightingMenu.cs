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


            Enemy monster = new Enemy("Pot Belly Pig", 5);

            StartEncounter(monster);

        }

        private static void StartEncounter(Enemy monster)
        {
            Console.WriteLine($"You have encountered {monster.Name}");
            Console.WriteLine("Based on your skills, you get to attack first");
            Console.WriteLine();
            Console.WriteLine("Your HP 20");
            Console.WriteLine($"{monster.Name} hit points {monster.HP}");

            DisplayMenu();

            string input = GatherInput.GetInput();
            
            ProcessInput(monster, input, rnd);
        }

        private static void ProcessInput(Enemy monster, string input, Random rnd)
        {
            switch (input.ToUpper())
            {
                case "A":
                    int damageAmount = rnd.Next(5);
                    Console.WriteLine($"You lash at the {monster.Name} and hit for {damageAmount}");
                    monster.TakeDamage(damageAmount);
                    if (monster.IsDead)
                    {
                        Console.WriteLine($"The {monster.Name} is dead!");
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

                case "R":
                    Console.WriteLine("You run away,fleeing and screaming. Luckily now one was around to see that failure. You loose 50 experiance points");
                    Console.ReadKey();
                    break;

                default:
                    break;
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("A");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Attack!");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("R");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Run away scared!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------------");
        }

        private static void ContinueEncounter(Enemy monster)
        {
            Console.WriteLine($"{monster.Name} hits you back for {GenRandomNumber.Next(1, 5)}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Your hit points 20");
            Console.WriteLine("**********************");
            Console.WriteLine($"{monster.Name} 's hit points {monster.HP}");
            DisplayMenu();
            string input = GatherInput.GetInput();
            ProcessInput(monster, input, rnd);

        }
    }
}
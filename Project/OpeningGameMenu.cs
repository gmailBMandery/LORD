using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace LORD
{
    class OpeningGameMenu
    {
        public OpeningGameMenu()
        {
            ShowMenu();

        }

        public void ShowMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please Login to Continue your adventure");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("If you are a new user, enter newuser as the user name.");
            string userName = GatherInput.GetUserName();
            UserName = userName;
            if(UserName.Trim().ToUpper() != "NEWUSER")
                Password = GatherInput.GetPassword();
            
            //Take this and go find data for user
            Console.Clear();
            if(userName.Trim().ToUpper() == "NEWUSER" )
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.CursorLeft = 2;
                Console.Write("What will you be called >>");
                UserName = Console.ReadLine();
                Console.WriteLine();
                Console.CursorLeft = 2;
                Console.Write("Provide a password >>");
                Password = Console.ReadLine();

                Program.player = new Player(UserName, Password);
                Player p = Program.player;
                ReadWritePlayer rwPlayer = new ReadWritePlayer(UserName, Password, p.ExperiencePoints
                    , p.Level, p.Gold, p.GoldInBank, p.Weapon.WeaponID, p.ArmourDress.ArmourID
                    , p.AttackStrength, p.DefensiveStrength, p.HitPoints, p.Charm, p.Gems
                    , p.PlayerFights, p.ForestFights, 0, p.AttackModifier);

                IFormatter formatter = new BinaryFormatter();
                Stream writeStream = new FileStream($"C:\\lord\\users\\{UserName}.txt", FileMode.Create, FileAccess.Write);
                formatter.Serialize(writeStream, rwPlayer);
                writeStream.Close();

                Console.Clear();
                Console.CursorLeft = 2;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Welcome, {UserName}. Adventure awaits beyond these gates!");
                Console.WriteLine("Press anykey continue to town square");
                return;

            }

            if (userName.Trim().Length>0)
            {
                Program.player = new Player(userName, 15,20,1,2,1);   
                Console.WriteLine($"Welcome back {userName}. You are feeling under the weather today!");
                Console.Write("Press anykey to continue to town");
                Console.ReadKey();
            }
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
    }
}

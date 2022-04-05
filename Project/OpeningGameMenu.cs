using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

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

                Program.player = new Player(UserName, Password,true);
 

                Console.Clear();
                Console.CursorLeft = 2;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Welcome, {UserName}. Adventure awaits beyond these gates!");
                Console.WriteLine("Press anykey continue to town square.");
                return;

            }

            if (userName.Trim().Length>0)
            {
                //All player data will of course be read from a file.
                //Program.player = new Player(UserName, Password);
                if (this.DoesPlayerFileExists())
                {
                    Program.player = new Player();
                    Program.player = Program.player.LoadPlayerData(UserName, Password);
                }
                else
                {
                    //new User
                    Console.WriteLine("User not found.");
                    Console.Write("press anykey to login again.");
                    Console.ReadKey();
                    this.ShowMenu();
                }

                if(Program.player.PlayerReady)
                {
                    Console.WriteLine($"Welcome back {UserName}. You are feeling under the weather today!");
                    Console.Write("Press anykey to continue to town");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Password invalid, press anykey to login again.");
                    Console.ReadKey();
                    this.ShowMenu();
                }
            }
        }

        private Boolean DoesPlayerFileExists()
        {
            if (File.Exists($"{Program.fileLocation}{this.UserName}.json"))
                return true;
            else
                return false;
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("Please Login to Continue your adventure");
            string userName = GatherInput.GetUserName();
            UserName = userName;

            //Take this and go find data for user
            Console.Clear();
            if (userName.Trim().Length>0)
            {
                Program.player = new Player(userName, 20);   
                Console.WriteLine($"Welcome back {userName}. You are feeling under the weather today!");
                Console.Write("Press anykey to continue to town");
                Console.ReadKey();
            }
        }

        public string UserName { get; set; }
    }
}

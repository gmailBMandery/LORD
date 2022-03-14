using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace LORD
{
    class Program
    {
        private static Boolean runGameLoop = true;
        public static Player player;
        static void Main(string[] args)
        {

            ////Create Weapon File
            //IFormatter formatter = new BinaryFormatter();
            //Stream writeStream = new FileStream("C:\\LORD\\weaponsList.txt", FileMode.Create, FileAccess.Write);

            //List<Weapon> weaponList = new List<Weapon>();

            //Weapon stick = new Weapon(1, 5);
            //Weapon dagger = new Weapon(5, 13);
            //weaponList.Add(stick);
            //weaponList.Add(dagger);

            //formatter.Serialize(writeStream, weaponList);
            //writeStream.Close();
            //writeStream.Dispose();




            while(runGameLoop)
            {
                MainGameLoop();
            }
        }

        private static void MainGameLoop()
        {
            OpeningGameMenu openingGameMenu = new OpeningGameMenu();
            if (openingGameMenu.UserName.Trim().Length == 0)
                openingGameMenu.ShowMenu();
            else
            {
                MainMenu m = new MainMenu();
                m.PaintMainMenu();
                runGameLoop = m.ProcessSelection(GatherInput.GetKeyedInput());
            }
        }
    }
}

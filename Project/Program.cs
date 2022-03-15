using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Encodings;
using System.Text;
using System.Security.Cryptography;

namespace LORD
{
    class Program
    {
        private static Boolean runGameLoop = true;
        public static Player player;
        static void Main(string[] args)
        {

            //Create Weapon File
            //IFormatter formatter = new BinaryFormatter();
            //Stream writeStream = new FileStream("C:\\LORD\\weaponsList.txt", FileMode.Create, FileAccess.Write);

            //List<Weapon> weaponList = new List<Weapon>();

            //Weapon stick = new Weapon(1, 5, "Stick", 100, 45);
            //Weapon dagger = new Weapon(5, 13, "Dagger", 150, 55);
            //weaponList.Add(stick);
            //weaponList.Add(dagger);


            //StringBuilder stringWeaponList = new StringBuilder();
            //stringWeaponList.Append(""+stick.ToString());
            //stringWeaponList.Append("$"+dagger.ToString());

            //string encrypedWeaponList = FileSecurity.Encrypt(stringWeaponList.ToString());
            //formatter.Serialize(writeStream, encrypedWeaponList);
            //writeStream.Close();
            //writeStream.Dispose();

            //Stream readStream = new FileStream("C:\\lord\\weaponsList.txt", FileMode.Open, FileAccess.Read);
            //string readString = formatter.Deserialize(readStream).ToString();
            //readStream.Close();

            //string decryptedString = FileSecurity.Decrypt(readString);

            //string[] weapons = decryptedString.Split('$');

            //Console.ReadKey();


            while (runGameLoop)
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

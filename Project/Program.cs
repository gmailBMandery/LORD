﻿using System;
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
        private static string gameDirectory = "c:\\lord";
        private static string userDirectory = "\\users";
        static void Main(string[] args)
        {

            //Check to see if we have the correct game directories created.
            DirectoryInfo di = new DirectoryInfo(gameDirectory+userDirectory);
            if (!di.Exists)
                di.Create();

            while (runGameLoop)
                MainGameLoop();
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

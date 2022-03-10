using System;

namespace ConsoleApp8
{
    class Program
    {
        private static Boolean runGameLoop = true;
        static void Main(string[] args)
        {
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
                runGameLoop = m.ProcessSelection(GatherInput.GetInput());
            }
        }
    }
}

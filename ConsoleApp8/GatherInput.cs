using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class GatherInput
    {
        public static string GetInput()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Make Your Selection>>");
            Console.ResetColor();
            return Console.ReadLine();
        }

        public static string GetUserName()
        {
            Console.Write("UserName>>");
            return Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iStepPhone.Menu.MenuComponents
{
    public static class ProgressBar
    {
        public static void Show()
        {
            Console.CursorVisible = false;
            Console.WriteLine("\n\n\n\n\n\n\n\t\t\t Starting iStepPhone... ");
           
            var rand = new Random();

            for (int i = 0; i <= 100; i++)
            {
                if (i < 25)
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (i < 50)
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                else if (i < 75)
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                else if (i < 100)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else
                    Console.ForegroundColor = ConsoleColor.Green;

                string load = string.Format("\t\t\t {0,-30} {1,3}%", new string((char)0x2592, i * 30 / 100), i);

                Console.CursorLeft = 0;
                Console.Write(load);
                Thread.Sleep(rand.Next(0, 100));
            }
            Console.WriteLine();
            Thread.Sleep(1000);
            Console.ResetColor();
        }
    }
}

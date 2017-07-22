using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStepPhone.Menu.MenuComponents
{
    public static class Header
    {
        public static void Show()
        {
            Console.Clear();
            Console.WriteLine(new string('*',80));
            for (int i = 0; i < 1; i++) Console.WriteLine();
            Console.WriteLine("\t\t\t\t iStepPhone");
            for (int i = 0; i < 2; i++) Console.WriteLine();
            Console.WriteLine(new string('*', 80));
        }

        
    }
}

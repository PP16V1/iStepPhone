using iStepPhone.SMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStepPhone.Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            MenuRender.Read();
            MenuRender.SelectMenu(MenuRender.menuItems.ToArray());



        }
    }
}

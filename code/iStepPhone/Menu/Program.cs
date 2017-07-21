using iStepPhone.Menu.MenuComponents;
using iStepPhone.Menu.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStepPhone.Menu
{
    public enum typeMenu { ITEM, ICON };
    class Program
    {
        static void Main(string[] args)
        {
            ProgressBar.Show();
            ShowMenu show = new ShowMenu();
            show.Start();

        }

    }
}
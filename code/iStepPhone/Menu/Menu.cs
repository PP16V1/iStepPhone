using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStepPhone.Menu
{
    public class Menu
    {
        public string[] item;
        public Menu()
        {
            item = new string[8] {
                "Address Book",
                "SMS",
                "Organizer",
                "Playmarket",
                "XO",
                "Snake",
                "File Manager",
                "API Checker"
            };
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace iStepPhone.Menu.MenuComponents
{
    public class Menu
    {
        public List<string> menuItems;
        private string path { get; set; }

        public Menu()
        {
            menuItems = new List<string>();
            path = @"../../cmn/config.xml";
            Read();
            MakeIcons();
        }

        public Menu(List<string> _menu)
        {
            menuItems = _menu;
        }


        //read row menu from config.xml
        private void Read()
        {
            var doc = XDocument.Load(path);

            foreach (var element in doc.Element("menu").Elements("menuItem"))
            {
                menuItems.Add(element.Element("name").Value);
            }
        }


        private void MakeIcons()
        {
            List<string> menuIcons = new List<string>();
            for (int i = 0; i < menuItems.Count; i++)
            {
                menuIcons.Add(menuItems[i] + "\t\t");
            }
            menuItems = menuIcons;
        }

    }
}

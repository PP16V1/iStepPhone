using iStepPhone.Menu.Loading;
using Menu.Loading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace iStepPhone.Menu.Tools
{
    public static class Deserializator
    {

        public static List<ItemMenu> DeserialMenu()
        {
            List<ItemMenu> listMenu = new List<ItemMenu>();
            try
            {
                var xDoc = XDocument.Load(@"../../cmn/config.xml");
                listMenu = xDoc.Element("menu").Elements("menuItem").Select(x =>
                  new ItemMenu
                  {
                      Name = x.Element("name").Value,
                      AssemblyName = x.Element("assemblyName").Value,
                      TypeName = x.Element("typeName").Value,
                      MethodToCall = x.Element("methodToCall").Value
                  }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return listMenu;
        }

        public static void DeserialColors()
        {
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

            try
            {
                List<UserSettings> settings = new List<UserSettings>();
                var xDoc = XDocument.Load("../../cmn/UserSettings.xml");
                settings = xDoc.Element("userSettings").Elements("settings").Select(x =>
                  new UserSettings
                  {
                      Foreground = colors[int.Parse(x.Element("foreground").Value)],
                      Background = colors[int.Parse(x.Element("background").Value)],
                      SelectedRow = colors[int.Parse(x.Element("selectedRow").Value)]
                  }).ToList();

                CurrentColor.Foreground = settings[0].Foreground;
                CurrentColor.Background = settings[0].Background;
                CurrentColor.SelectedRow = settings[0].SelectedRow;
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.Read();
            }


        }
    }
}


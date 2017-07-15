using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace iStepPhone.Menu
{
    class Test
    {
        public void Start()
        {
            Console.WriteLine("Scooby-doo");
        }
    }
    public static class MenuRender
    {
        public enum HighLight { AdressBook, Sms, Organizer, Playmarket, XO, Snake, FileManager, ApiChecker };
        public static List<string> menuItems = new List<string>();

        static void HightLightRow()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        static void DontHightLightRow()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Read()
        {
            Type t = typeof(Test);

            var doc = XDocument.Load(@"D:\Users\301-07\Documents\iStepPhone\code\iStepPhone\Menu\config.xml");

            foreach (var element in doc.Element("menu").Elements("menuItem"))
            {
                var method = t.GetMethod(element.Element("methodToCall").Value);  //узнаем метод, который надо вызвать
                method.Invoke(new Test(), null);  // вызываем на объекте new Test(), null - это спискок параметров, которые принимает метод 

                menuItems.Add(element.Element("name").Value);
            }
        }

        static HighLight ChangeSelectRow(HighLight position)
        {
            HighLight MinRow = HighLight.AdressBook;
            HighLight MaxRow = HighLight.ApiChecker;
            return (position > MaxRow) ? MinRow : (position < MinRow) ? MaxRow : position;
        }

        public static HighLight SelectMenu(string[] item)
        {
            HighLight position = 0;

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t iStepPhone");
                DontHightLightRow();

                

                switch (position)
                {
                    case HighLight.AdressBook:
                        HightLightRow();
                        Console.WriteLine(item[(int)HighLight.AdressBook]);
                        DontHightLightRow();
                        Console.WriteLine(item[(int)HighLight.Sms]);
                        Console.WriteLine(item[(int)HighLight.Organizer]);
                        Console.WriteLine(item[(int)HighLight.Playmarket]);
                        Console.WriteLine(item[(int)HighLight.XO]);
                        Console.WriteLine(item[(int)HighLight.Snake]);
                        Console.WriteLine(item[(int)HighLight.FileManager]);
                        Console.WriteLine(item[(int)HighLight.ApiChecker]);
                        break;
                    case HighLight.Sms:
                        Console.WriteLine(item[(int)HighLight.AdressBook]);
                        HightLightRow();
                        Console.WriteLine(item[(int)HighLight.Sms]);
                        DontHightLightRow();
                        Console.WriteLine(item[(int)HighLight.Organizer]);
                        Console.WriteLine(item[(int)HighLight.Playmarket]);
                        Console.WriteLine(item[(int)HighLight.XO]);
                        Console.WriteLine(item[(int)HighLight.Snake]);
                        Console.WriteLine(item[(int)HighLight.FileManager]);
                        Console.WriteLine(item[(int)HighLight.ApiChecker]);
                        break;
                    case HighLight.Organizer:
                        Console.WriteLine(item[(int)HighLight.AdressBook]);
                        Console.WriteLine(item[(int)HighLight.Sms]);
                        HightLightRow();
                        Console.WriteLine(item[(int)HighLight.Organizer]);
                        DontHightLightRow();
                        Console.WriteLine(item[(int)HighLight.Playmarket]);
                        Console.WriteLine(item[(int)HighLight.XO]);
                        Console.WriteLine(item[(int)HighLight.Snake]);
                        Console.WriteLine(item[(int)HighLight.FileManager]);
                        Console.WriteLine(item[(int)HighLight.ApiChecker]);
                        break;
                    case HighLight.Playmarket:
                        Console.WriteLine(item[(int)HighLight.AdressBook]);
                        Console.WriteLine(item[(int)HighLight.Sms]);
                        Console.WriteLine(item[(int)HighLight.Organizer]);
                        HightLightRow();
                        Console.WriteLine(item[(int)HighLight.Playmarket]);
                        DontHightLightRow();
                        Console.WriteLine(item[(int)HighLight.XO]);
                        Console.WriteLine(item[(int)HighLight.Snake]);
                        Console.WriteLine(item[(int)HighLight.FileManager]);
                        Console.WriteLine(item[(int)HighLight.ApiChecker]);
                        break;
                    case HighLight.XO:
                        Console.WriteLine(item[(int)HighLight.AdressBook]);
                        Console.WriteLine(item[(int)HighLight.Sms]);
                        Console.WriteLine(item[(int)HighLight.Organizer]);
                        Console.WriteLine(item[(int)HighLight.Playmarket]);
                        HightLightRow();
                        Console.WriteLine(item[(int)HighLight.XO]);
                        DontHightLightRow();
                        Console.WriteLine(item[(int)HighLight.Snake]);
                        Console.WriteLine(item[(int)HighLight.FileManager]);
                        Console.WriteLine(item[(int)HighLight.ApiChecker]);
                        break;
                    case HighLight.Snake:
                        Console.WriteLine(item[(int)HighLight.AdressBook]);
                        Console.WriteLine(item[(int)HighLight.Sms]);
                        Console.WriteLine(item[(int)HighLight.Organizer]);
                        Console.WriteLine(item[(int)HighLight.Playmarket]);
                        Console.WriteLine(item[(int)HighLight.XO]);
                        HightLightRow();
                        Console.WriteLine(item[(int)HighLight.Snake]);
                        DontHightLightRow();
                        Console.WriteLine(item[(int)HighLight.FileManager]);
                        Console.WriteLine(item[(int)HighLight.ApiChecker]);
                        break;
                    case HighLight.FileManager:
                        Console.WriteLine(item[(int)HighLight.AdressBook]);
                        Console.WriteLine(item[(int)HighLight.Sms]);
                        Console.WriteLine(item[(int)HighLight.Organizer]);
                        Console.WriteLine(item[(int)HighLight.Playmarket]);
                        Console.WriteLine(item[(int)HighLight.XO]);
                        Console.WriteLine(item[(int)HighLight.Snake]);
                        HightLightRow();
                        Console.WriteLine(item[(int)HighLight.FileManager]);
                        DontHightLightRow();
                        Console.WriteLine(item[(int)HighLight.ApiChecker]);
                        break;
                    case HighLight.ApiChecker:
                        Console.WriteLine(item[(int)HighLight.AdressBook]);
                        Console.WriteLine(item[(int)HighLight.Sms]);
                        Console.WriteLine(item[(int)HighLight.Organizer]);
                        Console.WriteLine(item[(int)HighLight.Playmarket]);
                        Console.WriteLine(item[(int)HighLight.XO]);
                        Console.WriteLine(item[(int)HighLight.Snake]);
                        Console.WriteLine(item[(int)HighLight.FileManager]);
                        HightLightRow();
                        Console.WriteLine(item[(int)HighLight.ApiChecker]);
                        DontHightLightRow();
                        break;
                }
                Thread.Sleep(5);

                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.DownArrow)
                    position++;
                else if (key.Key == ConsoleKey.UpArrow)
                    position--;
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\t" + item[(int)position]);
                    DontHightLightRow();
                    //Console.Read();
                    return position;
                }

                position = ChangeSelectRow(position);

                Console.Clear();

            } while (true);
        }
    }
}


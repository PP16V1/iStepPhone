using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using Abstractions;

namespace iStepPhone.PlayMarket
{
    public class PlayMarket : Abstraction
    {
        private ConsoleKey key;
        private XmlDocument doc = new XmlDocument();
        private XmlElement root;
        private List<string[]> gameImage = new List<string[]>();

        public override void startApplication()
        {
           // Console.SetWindowSize(31, 27);
            //Console.SetBufferSize(31, 27);         
            Console.CursorVisible = false;
            Console.Title = "PlayMarket";
            parseXML();
            startSelection();
        }

        private void parseXML()
        {
            doc.Load("./MarketResources/Applications.xml");
            root = doc.DocumentElement;
            foreach (XmlNode image in root.ChildNodes)
            {
                gameImage.Add(File.ReadAllLines(image.InnerText));
            }
        }

        private void startSelection()
        {
            Console.Clear();
            int index = 0;
            foreach (var img in gameImage[0])
            {
                Console.WriteLine(img);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press Enter to select");
            Console.ResetColor();
            do
            {
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.DownArrow)
                {
                    index++;
                    if (index > gameImage.Count - 1) index = 0;
                    showApplicationIcon(index);
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    index--;
                    if (index < 0) index = gameImage.Count - 1;
                    showApplicationIcon(index);
                }
                else if (key == ConsoleKey.Enter)
                {
                    gameMenu(index);
                }
            } while (key != ConsoleKey.Escape);
            doc.Save("./MarketResources/Applications.xml");
        }

        private void gameMenu(int index)
        {
            do
            {
                if (root.ChildNodes[index].Attributes[2].Value == "false")
                {
                    Console.WriteLine(root.ChildNodes[index].Attributes[0].Value + " isnt installed\nInstall this? Y/N");
                    key = Console.ReadKey().Key;
                    if (key == ConsoleKey.Y)
                    {
                        root.ChildNodes[index].Attributes[2].Value = "true";
                        showLoadProgress("installed");
                    }
                    else if (key == ConsoleKey.N)
                    {
                        startSelection();
                    }
                    else
                    {
                        break;
                    }
                }
                else if (root.ChildNodes[index].Attributes[2].Value == "true")
                {
                    Console.WriteLine("1:Play " + root.ChildNodes[index].Attributes[0].Value);
                    Console.WriteLine("2:Delete " + root.ChildNodes[index].Attributes[0].Value);
                    key = Console.ReadKey().Key;
                    if (key == ConsoleKey.D1)
                    {
                        Console.Clear();
                       Activator.CreateInstance(root.ChildNodes[index].Attributes[3].Value,
                                                 root.ChildNodes[index].Attributes[4].Value).Unwrap();
                        startSelection();
                    }
                    else if (key == ConsoleKey.D2)
                    {
                        root.ChildNodes[index].Attributes[2].Value = "false";
                        showLoadProgress("deleted");
                    }
                    else
                    {
                        break;
                    }
                }
            } while (key!=ConsoleKey.Escape);
        }

        private void showLoadProgress(string message)
        {
            Console.WriteLine();
            for (int i = 0; i < 12; i++)
            {
                Console.Write('█');
                System.Threading.Thread.Sleep(100);
            }
            Console.WriteLine();
            Console.WriteLine("Succes " + message);
            System.Threading.Thread.Sleep(1000);
            startSelection();
        }

        private void showApplicationIcon(int index)
        {
            Console.Clear();
            foreach (var img in gameImage[index])
            {
                Console.WriteLine(img);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press Enter to select");
            Console.ResetColor();
        }
    }
}

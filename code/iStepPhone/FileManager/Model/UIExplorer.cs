using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iStepPhone.FileManager.Abstract;
using iStepPhone.FileManager.Factory;

namespace iStepPhone.FileManager.Model
{
    public class UIExplorer : AUIExplorer
    {
        private List<int> currItem;

        public UIExplorer()
        {
            currItem = new List<int>();
        }

        public void HighLightRow()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void DontHighLightRow()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        private bool IsCursorThere(List<UserDirectoryClass> Root, UserDirectoryClass cItem)
        {
            List<UserDirectoryClass> userItems = Root;
            int num;
            for (num = 0; num < currItem.Count - 1; num++)
            {
                userItems = userItems[currItem[num]].Children;
            }

            if (userItems[currItem[num]].Equals(cItem)) return true;
            return false;
        }

        private void ShowMenueLevel(List<UserDirectoryClass> Items, List<UserDirectoryClass> Root, int cLevel)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (IsCursorThere(Root, Items[i]))
                {
                    HighLightRow();
                }
                else
                {
                    DontHighLightRow();
                }

                Console.Write(new string(' ', cLevel * 2));
                Console.WriteLine(Items[i]);
                if (Items[i].IsActive)
                {
                    ShowMenueLevel(Items[i].Children, Root, cLevel + 1);
                }
            }
        }

        private void DoAction(List<UserDirectoryClass> Items)
        {
            List<UserDirectoryClass> userItems = Items;
            int num;
            for (num = 0; num < currItem.Count - 1; num++)
            {
                userItems = userItems[currItem[num]].Children;
            }
            userItems[currItem[num]].IsActive = !userItems[currItem[num]].IsActive;
            if (userItems[currItem[num]].IsActive)
            {
                if (userItems[currItem[num]].Children.Count != 0)
                    currItem.Add(0);
            }
        }

        private void AddCursorPosition(List<UserDirectoryClass> Items, int cLevel)
        {
            if (cLevel == currItem.Count - 1)
            {
                if (currItem[cLevel] + 1 < Items.Count)
                    currItem[cLevel] = currItem[cLevel] + 1;
                else
                    if (cLevel != 0) currItem.RemoveAt(cLevel);
            }
            else
            {
                AddCursorPosition(Items[currItem[cLevel]].Children, cLevel + 1);
                if (cLevel == currItem.Count - 1)
                {
                    if (currItem[cLevel] + 1 < Items.Count)
                        currItem[cLevel] = currItem[cLevel] + 1;
                    else
                        if (cLevel != 0) currItem.RemoveAt(cLevel);
                }
            }
        }

        private void DecCursorPosition(List<UserDirectoryClass> Items, int cLevel)
        {
            if (cLevel == currItem.Count - 1)
            {
                if (currItem[cLevel] != 0)
                    currItem[cLevel] = currItem[cLevel] - 1;
                else
                    if (cLevel != 0) currItem.RemoveAt(cLevel);
            }
            else
            {
                DecCursorPosition(Items[currItem[cLevel]].Children, cLevel + 1);
            }

        }

        private void DisplayFunctionKey()
        {
            DontHighLightRow();
            Console.WriteLine("\nF1-Help\t\tF5-Copy\t\tF6-Move\nF7-Create Dir\tF8-Delete");
        }


        public override void ShowExplorer(List<UserDirectoryClass> Items)
        {
            currItem.Add(0);
            int cLevel = 0;
            do
            {
                ShowMenueLevel(Items, Items, cLevel);
                DisplayFunctionKey();
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.DownArrow)
                {
                    AddCursorPosition(Items, cLevel);
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    DecCursorPosition(Items, cLevel);
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    DoAction(Items);
                }
                Console.Clear();
            } while (true);
        }
    }
}

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

        private UserDirectoryClass ShowExplorerLevel(List<UserDirectoryClass> Items, List<UserDirectoryClass> Root, int cLevel)
        {
            UserDirectoryClass result = null;
            for (int i = 0; i < Items.Count; i++)
            {
                if (IsCursorThere(Root, Items[i]))
                {
                    result = Items[i];
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
                    UserDirectoryClass tmp = ShowExplorerLevel(Items[i].Children, Root, cLevel + 1);
                    if (tmp != null) result = tmp; 
                }
            }
            return result;
        }

        private void DoActionForSelect(List<UserDirectoryClass> Items)
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
                {
                    if (Items[currItem[cLevel]].IsActive && Items[currItem[cLevel]].Children.Count > 0)
                        currItem.Add(0);
                    else
                        currItem[cLevel] = currItem[cLevel] + 1;
                }
                else
                {
                    if (Items[currItem[cLevel]].IsActive && Items[currItem[cLevel]].Children.Count > 0)
                        currItem.Add(0);
                    else                    
                        if (cLevel != 0) currItem.RemoveAt(cLevel);
                }
            }
            else
            {
                AddCursorPosition(Items[currItem[cLevel]].Children, cLevel + 1);
                if (cLevel == currItem.Count - 1)
                {
                    if (currItem[cLevel] + 1 < Items.Count)
                    {
                            currItem[cLevel] = currItem[cLevel] + 1;
                    }
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
            Console.WriteLine("\nF1-Help\t\tF3- View File\tF5-Copy\t\tF6-Move\nF7-Create Dir\tF8-Delete\tF10-Exit");
        }

        private void DisplayImplementationFunctionKey()
        {
            DontHighLightRow();
            Console.WriteLine("Enter- Select Item\t\tF10-Exit");
        }

        public override void ShowExplorer(List<UserDirectoryClass> Items)
        {
            currItem.Add(0);
            UserDirectoryClass selectedItem = null;
            int cLevel = 0;
            do
            {
                selectedItem = ShowExplorerLevel(Items, Items, cLevel);
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
                    DoActionForSelect(Items);
                }
                else if (key.Key == ConsoleKey.F3)
                {
                    if (selectedItem != null)
                        new UIFileViewer(selectedItem).View();
                }
                else if (key.Key == ConsoleKey.F5)
                {
                    if (selectedItem != null)
                        new UICopier(this, Items, selectedItem).Copy();
                }
                else if (key.Key == ConsoleKey.F7)
                {
                    if (selectedItem != null)
                        new UIDirectoryCreator(selectedItem, currItem).CreateDirectory();
                }
                else if (key.Key == ConsoleKey.F10)
                {
                    break;
                }
                Console.Clear();
            } while (true);
        }


        private void DoActionForImplement(UserDirectoryClass selected, IExecuteble action)
        {
            action.Execute(selected);
        }

        public void ShowExplorerForImplementation(List<UserDirectoryClass> Items, IExecuteble action, string message)
        {
            UserDirectoryClass selectedItem = null;
            int cLevel = 0;
            do
            {
                Console.WriteLine(message);
                selectedItem = ShowExplorerLevel(Items, Items, cLevel);
                DisplayImplementationFunctionKey();
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
                    DoActionForImplement(selectedItem, action);
                    break;
                }
                else if (key.Key == ConsoleKey.F10)
                {
                    break;
                }
                Console.Clear();
            } while (true);

        }
    }
}

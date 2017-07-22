using iStepPhone.Menu.Loading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iStepPhone.Menu.MenuComponents
{
    /// <summary>
    /// Class MenuRender
    /// MenuRender can be used by creating a menu from the List<string> or xml-file
    /// </summary>

    public class MenuRender
    {
        public Menu menu;

        public MenuRender(Menu _menu)
        {
            menu = _menu;
        }

        #region HighLight
        private void HighLightItem(int position)
        {
            for (int i = 0; i < menu.menuItems.Count; i++)
            {
                if (i == position)
                {
                    Console.ForegroundColor=CurrentColor.SelectedRow;
                    Console.WriteLine(menu.menuItems[i]);
                    Console.ForegroundColor = CurrentColor.Foreground;
                }
                else
                {
                    Console.WriteLine(menu.menuItems[i]);
                }
            }
        }

        private void HighLightIcon(int position)
        {
            for (int i = 0; i < menu.menuItems.Count; i++)
            {
                if (i % 3 == 0)
                    Console.Write("\t");

                if (i == position)
                {
                    Console.ForegroundColor = CurrentColor.SelectedRow;
                    Console.Write(menu.menuItems[i]);
                    Console.ForegroundColor = CurrentColor.Foreground;
                }
                else
                {
                    Console.Write(menu.menuItems[i]);
                }

                if ((i + 1) % 3 == 0)
                {
                    for(int j=0; j<3; j++) Console.WriteLine(); 
                }
            }
            Console.WriteLine();
            for (int i = 0; i < 2; i++) Console.WriteLine();
            Console.WriteLine(new string('*', 80));
        }
        #endregion

        ///<summary>
        ///Method returns the position of the selected menu item and -1 in case of exit
        ///</summary>
        /// <param name="type">Type Menu: ICON or ITEM</param>
        public int SelectMenu(typeMenu type=typeMenu.ITEM)
        {
            ConsoleKey next, prev;
            Console.ForegroundColor = CurrentColor.Foreground;
            Console.BackgroundColor = CurrentColor.Background;
            
            int position = 0;
            do
            {
                Header.Show();
                if (type == typeMenu.ITEM)
                {
                    HighLightItem(position);
                    next = ConsoleKey.DownArrow;
                    prev = ConsoleKey.UpArrow;
                }
                else
                {
                    HighLightIcon(position);
                    next = ConsoleKey.RightArrow;
                    prev = ConsoleKey.LeftArrow;
                }
                Thread.Sleep(5);

                var key = Console.ReadKey();
                if (key.Key == next)
                    position++;
                else if (key.Key == prev)
                    position--;
                else if (key.Key == ConsoleKey.Escape)
                {
                    position = -1;
                    break;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    return position;
                }

                position = ChangeSelectRow(position);

                Console.Clear();

            } while (position != -1);
            return -1;
        }

        private int ChangeSelectRow(int position)
        {
            int minPos = 0;
            int maxPos = menu.menuItems.Count - 1;
            return (position > maxPos) ? minPos : (position < minPos) ? maxPos : position;
        }

    }
}


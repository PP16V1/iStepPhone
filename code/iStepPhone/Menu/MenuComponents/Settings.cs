using iStepPhone.Menu.Loading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iStepPhone.Menu.MenuComponents
{
    
    public class Settings
    {
        ConsoleColor currentForeground { get; set; } = ConsoleColor.White;
        ConsoleColor currentBackground { get; set; } = ConsoleColor.Black;
        ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

        public void Start()
        {
            Menu menu = new Menu(new List<string> {
                "Set foreground color",
                "Set background color"
            });

            MenuRender mr = new MenuRender(menu);

            int pos = 0;
            do
            {
                Header.Show();
                
                pos =mr.SelectMenu();
                switch (pos)
                {
                    case 0:
                        SetForeground();
                        break;
                    case 1:
                        SetBackground();
                        break;
                }
                if (pos == -1)
                    break;
            } while (pos != -1);
            Console.WriteLine("exit");
        }


        private void SetForeground()
        {
            Console.Clear();
            Header.Show();
            List<string> colorSelection=new List<string>();

            Console.WriteLine("All the foreground colors");
            foreach (var color in colors)
            {
                if (color == currentBackground)
                {
                    colorSelection.Add($"   The foreground color is {color}");
                    continue;
                }

                Console.ForegroundColor = color;
                colorSelection.Add($"   The foreground color is {color}");
                Console.WriteLine("   The foreground color is {0}.", color);
            }
            Console.WriteLine();
            Console.WriteLine("Enter - choose color");
            Console.Read();


            MenuRender mr= new MenuRender(new Menu(colorSelection));

            int pos = mr.SelectMenu();
            if (pos != -1)
            {
                AcceptForeground(pos);
            }
            Console.Read();
        }

        private void SetBackground()
        {
            Console.Clear();
            Header.Show();
            List<string> colorSelection = new List<string>();

            Console.WriteLine("All the background colors");
            foreach (var color in colors)
            {
                if (color == currentForeground)
                {
                    colorSelection.Add($"   The background color is {color}");
                    continue;
                }

                Console.BackgroundColor = color;
                colorSelection.Add($"   The background color is {color}");
                Console.WriteLine("   The background color is {0}.", color);
            }
            Console.WriteLine();
            Console.WriteLine("Enter - choose color");
            Console.Read();


            MenuRender mr = new MenuRender(new Menu(colorSelection));

            int pos = mr.SelectMenu();
            if (pos != -1)
            {
                AcceptBackground(pos);
            }
            Console.Read();
        }


        private void AcceptForeground(int pos)
        {
            if (CurrentColor.SelectedRow == ConsoleColor.Green && CurrentColor.SelectedRow == colors[pos])
                CurrentColor.SelectedRow = ConsoleColor.White;
            else
                CurrentColor.SelectedRow = ConsoleColor.Green;


            if (colors[pos] != CurrentColor.Background)
                CurrentColor.Foreground = colors[pos];
            else
            {
                Console.WriteLine(new string('*', 80));
                Console.WriteLine();
                Console.WriteLine("Oops... You can not do this");
                Console.WriteLine("Foreground should not be equal Background");
                Console.Read();
            }
           
        }


        private void AcceptBackground(int pos)
        {
            if (CurrentColor.SelectedRow == ConsoleColor.Green && CurrentColor.SelectedRow == colors[pos])
                CurrentColor.SelectedRow = ConsoleColor.White;
            else
                CurrentColor.SelectedRow = ConsoleColor.Green;


            if (colors[pos] != CurrentColor.Foreground)
                CurrentColor.Background = colors[pos];
            else
            {
                Console.WriteLine(new string('*', 80));
                Console.WriteLine();
                Console.WriteLine("Oops... You can not do this");
                Console.WriteLine("Foreground should not be equal Background");
                Console.Read();
            }
        }


        public void Show()
        {
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            
            ConsoleColor currentBackground = Console.BackgroundColor;
            ConsoleColor currentForeground = Console.ForegroundColor;

            Console.WriteLine("All the foreground colors except {0}, the background color:",
                              currentBackground);
            foreach (var color in colors)
            {
                if (color == currentBackground) continue;

                Console.ForegroundColor = color;
                Console.WriteLine("   The foreground color is {0}.", color);
            }
            Console.WriteLine();
            // Restore the foreground color.
            Console.ForegroundColor = currentForeground;

            // Display each background color except the one that matches the current foreground color.
            Console.WriteLine("All the background colors except {0}, the foreground color:",
                              currentForeground);
            foreach (var color in colors)
            {
                if (color == currentForeground) continue;

                Console.BackgroundColor = color;
                Console.WriteLine("   The background color is {0}.", color);
            }

            // Restore the original console colors.
            Console.ResetColor();
            Console.WriteLine("\nOriginal colors restored...");
        }
    }
}

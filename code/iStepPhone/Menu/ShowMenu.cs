using iStepPhone.Menu.Loading;
using iStepPhone.Menu.Tools;
using Menu.Loading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iStepPhone.Menu.MenuComponents
{
    public class ShowMenu
    {
        public void Start()
        {
            var itemMenu = Deserializator.DeserialMenu();
            Deserializator.DeserialColors();

            MenuRender mr = new MenuRender(new Menu());
            int numRow = 0;
            do
            {
                numRow = mr.SelectMenu(typeMenu.ICON);

                if (numRow == -1)
                    break;

                try
                {
                    var instance = Factory.CreateInstance(itemMenu[numRow].AssemblyName, itemMenu[numRow].TypeName);


                    Type type = instance.GetType();
                    MethodInfo method = type.GetMethod(itemMenu[numRow].MethodToCall);
                    method.Invoke(instance, null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }





                #region not_finished
                if (numRow != -1)
                    Console.WriteLine(itemMenu[numRow].MethodToCall);

                if (numRow == 8)
                {
                    Header.Show();
                    Settings settings = new Settings();
                    settings.Start();
                }

                Thread.Sleep(200);
                Console.Read();
                #endregion

            } while (numRow != -1);

            Serializator.SerializSettings(SaveColor());

        }


        private string[] SaveColor()
        {
            string[] saveSettings = new string[3];
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i] == CurrentColor.Foreground)
                    saveSettings[0] = i.ToString();
                if (colors[i] == CurrentColor.Background)
                    saveSettings[1] = i.ToString();
                if (colors[i] == CurrentColor.SelectedRow)
                    saveSettings[2] = i.ToString();
            }
            return saveSettings;
        }
    }
}

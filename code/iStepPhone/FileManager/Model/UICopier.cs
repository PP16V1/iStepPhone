using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iStepPhone.FileManager.Abstract;
using iStepPhone.FileManager.Factory;

namespace iStepPhone.FileManager.Model
{
    public class UICopier: IExecuteble
    {
        private UIExplorer explorer;
        private List<UserDirectoryClass> Items;
        private UserDirectoryClass selected;

        public UICopier(UIExplorer _explorer, List<UserDirectoryClass> items, UserDirectoryClass _selected)
        {
            explorer = _explorer;
            Items = items;
            selected = _selected;
        }

        public void Copy()
        {
            Console.Clear();
            string str = string.Format("You are about to copy file {0}\n Please, select the destination pass and pree \"Enter\"\n", selected.Name);
            explorer.ShowExplorerForImplementation(Items, this, str);
        }

        public void Execute(UserDirectoryClass destination)
        {
            Console.WriteLine("Coping");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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


        private void CopyFile(UserDirectoryClass source, UserDirectoryClass baseDestination)
        {
            if(!File.Exists(source.FullName))
            {
                return;
            }

            if(!File.Exists(Path.Combine(baseDestination.FullName, source.Name)))
            {
                new FileInfo(source.FullName).CopyTo(Path.Combine(baseDestination.FullName, source.Name));
                UserDirectoryClass destination = new UserDirectoryClass();
                destination.Name = source.Name;
                destination.Children = null;
                destination.FullName = Path.Combine(baseDestination.FullName, source.Name);
                baseDestination.Children.Add(destination);
            }
        }

        private void CopyDirectory(UserDirectoryClass source, UserDirectoryClass baseDestination)
        {
            if (!Directory.Exists(source.FullName))
            {
                return;
            }

            if (!Directory.Exists(Path.Combine(baseDestination.FullName, source.Name)))
            {
                Directory.CreateDirectory(Path.Combine(baseDestination.FullName, source.Name));
            }

            UserDirectoryClass destination = new UserDirectoryClass();
            int index = -1;
            if ((index = baseDestination.Children.FindIndex(x => x.FullName == Path.Combine(baseDestination.FullName, source.Name))) < 0)
            {
                destination.Name = source.Name;
                destination.FullName = Path.Combine(baseDestination.FullName, source.Name);
                baseDestination.Children.Add(destination);
            }
            else
            {
                destination = baseDestination.Children[index];
            }

            foreach (UserDirectoryClass item in source.Children)
            {
                if (Directory.Exists(item.FullName))
                    CopyDirectory(item, destination);

                if (File.Exists(item.FullName))
                    CopyFile(item, destination);
            }
        }

        public void Execute(UserDirectoryClass destination)
        {
            if (File.Exists(selected.FullName))
                CopyFile(selected, destination);

            if (Directory.Exists(selected.FullName))
                CopyDirectory(selected, destination);
        }
    }
}

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
    public class UIMover : IExecuteble
    {
        private UIExplorer explorer;
        private List<UserDirectoryClass> Items;
        private UserDirectoryClass selected;
        private List<UserDirectoryClass> ItemsWithSelected;

        public UIMover(UIExplorer _explorer, List<UserDirectoryClass> items, UserDirectoryClass _selected, List<UserDirectoryClass> _ItemsWithSelected)
        {
            explorer = _explorer;
            Items = items;
            selected = _selected;
            ItemsWithSelected = _ItemsWithSelected;
        }

        public void Move()
        {
            Console.Clear();
            string str = string.Format("You are about to move file {0}\n Please, select the destination pass and pree \"Enter\"\n", selected.Name);
            explorer.ShowExplorerForImplementation(Items, this, str);
        }


        private bool MoveFile(UserDirectoryClass source, UserDirectoryClass baseDestination)
        {
            if (!File.Exists(source.FullName))
            {
                return false;
            }

            if (File.Exists(Path.Combine(baseDestination.FullName, source.Name)))
            {
                return false;
            }

            new FileInfo(source.FullName).MoveTo(Path.Combine(baseDestination.FullName, source.Name));
            UserDirectoryClass destination = new UserDirectoryClass();
            destination.Name = source.Name;
            destination.Children = null;
            destination.FullName = Path.Combine(baseDestination.FullName, source.Name);
            baseDestination.Children.Add(destination);

            int numSelected;
            if ((numSelected = ItemsWithSelected.FindIndex(x => x.FullName == selected.FullName))>=0)
            {
                ItemsWithSelected.RemoveAt(numSelected);
            }

            return true;
        }

        private void MoveItemDirectory(UserDirectoryClass source, UserDirectoryClass baseDestination)
        {
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
            foreach(UserDirectoryClass items in source.Children)
            {
                MoveItemDirectory(items, destination);
            }
        }

        private bool MoveDirectory(UserDirectoryClass source, UserDirectoryClass baseDestination)
        {
            if (!Directory.Exists(source.FullName))
            {
                return false;
            }


            if (Directory.Exists(Path.Combine(baseDestination.FullName, source.Name)))
            {
                return false;
            }

            new DirectoryInfo(source.FullName).MoveTo(Path.Combine(baseDestination.FullName, source.Name));
            MoveItemDirectory(source, baseDestination);

            int numSelected;
            if ((numSelected = ItemsWithSelected.FindIndex(x => x.FullName == selected.FullName)) >= 0)
            {
                ItemsWithSelected.RemoveAt(numSelected);
            }
            return true;
        }

        public void Execute(UserDirectoryClass destination)
        {
            if (Directory.Exists(destination.FullName))
            {
                if (File.Exists(selected.FullName))
                     MoveFile(selected, destination);

                if (Directory.Exists(selected.FullName))
                     MoveDirectory(selected, destination);
            }
        }
    }
}

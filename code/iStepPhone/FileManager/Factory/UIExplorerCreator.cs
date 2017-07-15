using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace iStepPhone.FileManager.Factory
{
    public class UserDirectoryClass
    {
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public List<UserDirectoryClass> Children { get; set; }
        public UserDirectoryClass()
        {
            Children = new List<UserDirectoryClass>();
            IsActive = false;
        }
        public override string ToString()
        {
            return Name;
        }
    }

    class UIExplorerCreator
    {
        public List<UserDirectoryClass> MakingDirrectoryTree(string root)
        {
            DirectoryInfo dir = new DirectoryInfo(root);
            List<UserDirectoryClass> list = new List<UserDirectoryClass>();
            foreach (var item in dir.GetDirectories())
            {
                UserDirectoryClass userDir = new UserDirectoryClass();
                userDir.Name = item.Name.ToUpper();
                userDir.FullName = item.FullName;
                list.Add(userDir);
                userDir.Children.AddRange(MakingDirrectoryTree(item.FullName));
            }

            foreach (var item in dir.GetFiles())
            {
                UserDirectoryClass userDir = new UserDirectoryClass();
                userDir.Name = item.Name;
                userDir.FullName = item.FullName;
                list.Add(userDir);
            }
            return list;
        }
    }
}

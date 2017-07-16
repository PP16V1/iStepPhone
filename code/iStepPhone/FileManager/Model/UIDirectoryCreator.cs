using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iStepPhone.FileManager.Factory;
using System.IO;

namespace iStepPhone.FileManager.Model
{
    public class UIDirectoryCreator
    {
        private UserDirectoryClass creatDir;
        private List<int> currItemExplorer;

        public UIDirectoryCreator(UserDirectoryClass item, List<int> currItemExpl)
        {
            creatDir = item;
            currItemExplorer = currItemExpl;
        }

        public void CreateDirectory()
        {
            Console.Clear();
            FileAttributes attr = File.GetAttributes(creatDir.FullName);

            if ((attr & FileAttributes.Directory) != FileAttributes.Directory)
            {
                Console.WriteLine("The file \"{0}\" counld not accept us a base dirrectory.", creatDir.Name);
                Console.WriteLine("Press any key to continue ...\n\n");
                Console.ReadLine();
                return;
            }

            string nDir = null;
            Console.WriteLine("You are about to create a new directory.\nto the pass {0}\n Please, enter tha name of the new directory\n", creatDir.FullName);
            nDir=Console.ReadLine();

            if (nDir!=null)
            {
                DirectoryInfo dir = new DirectoryInfo(creatDir.FullName);
                dir.CreateSubdirectory(nDir);

                if (creatDir.Children == null)
                    creatDir.Children = new List<UserDirectoryClass>();

                creatDir.IsActive = true;

                UserDirectoryClass userDir = new UserDirectoryClass();
                userDir.Name = nDir.ToUpper();
                userDir.FullName = creatDir.FullName+@"\"+nDir;
                userDir.IsActive = true;
                currItemExplorer.Add(creatDir.Children.Count);
                userDir.Children = new List<UserDirectoryClass>();

                creatDir.Children.Add(userDir);
            }


        }
    }
}

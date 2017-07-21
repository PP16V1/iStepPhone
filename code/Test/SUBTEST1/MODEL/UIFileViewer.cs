using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iStepPhone.FileManager.Factory;

namespace iStepPhone.FileManager.Model
{
    public class UIFileViewer
    {
        private UserDirectoryClass FileToView;

        public UIFileViewer(UserDirectoryClass File)
        {
            FileToView = File;
        }

        public void View()
        {
            Console.Clear();
            try
            {
                using (StreamReader reader = new StreamReader(FileToView.FullName))
                {
                    Console.WriteLine("The file \"{0}\" was opened", FileToView.FullName);
                    Console.WriteLine("Press any key to continue ...\n\n");
                    do
                    {
                        Console.WriteLine(reader.ReadLine());
                    } while (reader.Peek() != -1);
                }
            }
            catch(Exception)
            {
                Console.WriteLine("The file \"{0}\" can't be opened", FileToView.FullName);
                Console.WriteLine("Press any key to continue ...\n\n");
            }
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iStepPhone.FileManager.Abstract;
using iStepPhone.FileManager.Factory;

namespace iStepPhone.FileManager
{
    public class FileManager
    {
        private string Root;
        public FileManager()
        {
            this.Root = @"D:\Users\301-01\Documents\iStepPhone1";
        }

        public FileManager(string root)
        {
            Root = root;
        }

        public void Show()
        {
            AUIExplorer uiExplorer = (CreateObject.CreateInstance("iStepPhone.FileManager.Model.UIExplorer", "FileManager") as AUIExplorer);
            uiExplorer.ShowExplorer(new UIExplorerCreator(Root).MakingDirrectoryTree());
        }
    }
}

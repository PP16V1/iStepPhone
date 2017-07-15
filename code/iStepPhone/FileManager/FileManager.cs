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
        public void Show(string root)
        {
            AUIExplorer uiExplorer = (CreateObject.CreateInstance("iStepPhone.FileManager.Model.UIExplorer", "FileManager") as AUIExplorer);
            uiExplorer.ShowExplorer(new UIExplorerCreator().MakingDirrectoryTree(root));
        }
    }
}

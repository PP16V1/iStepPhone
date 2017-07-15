using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iStepPhone.FileManager.Factory;

namespace iStepPhone.FileManager.Abstract
{
    public abstract class AUIExplorer
    {
        public abstract void ShowExplorer(List<UserDirectoryClass> Items);
    }
}

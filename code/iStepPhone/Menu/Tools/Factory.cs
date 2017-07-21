using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStepPhone.Menu.Tools
{
    public static class Factory
    {
        public static object CreateInstance(string typeName, string AssemblyName)
        {
            var instance = Activator.CreateInstance(AssemblyName, typeName).Unwrap();
            return instance;
        }
    }
}

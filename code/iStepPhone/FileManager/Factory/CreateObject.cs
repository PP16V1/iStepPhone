using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStepPhone.FileManager.Factory
{
    class CreateObject
    {
        public static object CreateInstance(string typeName, string AssemblyName)
        {
            var instance = Activator.CreateInstance(AssemblyName, typeName).Unwrap();
            return instance;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iStepPhone.Organise.Factory
{
    public class CreateObject
    {
        public static object CreateInstance(string typeName, string AssemblyName)
        {
            var instance = Activator.CreateInstance(AssemblyName, typeName).Unwrap();
            return instance;
        }
    }
}
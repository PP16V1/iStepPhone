using iStepPhone.SMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions;

namespace Menu
{
    class Program
    {
        static void Main(string[] args)
        {
          var market=(Abstraction)Activator.CreateInstance("iStepPhone.PlayMarket", "iStepPhone.PlayMarket.PlayMarket").Unwrap();
            market.startApplication();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStepPhone.Menu.Loading
{
    public static class CurrentColor
    {
        public static ConsoleColor Foreground { get; set; } = ConsoleColor.White;
        public static ConsoleColor Background { get; set; } = ConsoleColor.Black;
        public static ConsoleColor SelectedRow { get; set; } = ConsoleColor.Green;
        
    }
    
}

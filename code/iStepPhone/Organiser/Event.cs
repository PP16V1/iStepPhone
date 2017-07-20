using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStepPhone.Organise
{
    public class Event
    {
        public DateTime Datetime { get; set; }
        public string Name { get; set; }
        public Event(DateTime datetime, string name)
        {
            Datetime = datetime;
            Name = name;
        }
    }
}

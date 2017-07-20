using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iStepPhone.Organise;

namespace OrganaiserTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Organiser organiser = new Organiser();
            organiser.PrintCalendar();
            organiser.AddEvent(new DateTime(2017, 7, 22), "Pass exam");
            organiser.AddEvent(new DateTime(2017, 7, 21), "Finish this job");
            organiser.ShowListEvents();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStepPhone.Organise
{
    public class Organiser
    {
        public List<Event> Events { get; }
        public void PrintCalendar()
        {
            Console.WriteLine("Mon\tTue\tWed\tThu\tFri\tSat\tSun");
            DateTime first = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            int counter = 0;
            switch (first.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    counter = 1;
                    break;
                case DayOfWeek.Tuesday:
                    Console.Write("\t");
                    counter = 2;
                    break;
                case DayOfWeek.Wednesday:
                    Console.Write("\t \t");
                    counter = 3;
                    break;
                case DayOfWeek.Thursday:
                    Console.Write("\t \t \t");
                    counter = 4;
                    break;
                case DayOfWeek.Friday:
                    Console.Write("\t \t \t \t");
                    counter = 5;
                    break;
                case DayOfWeek.Saturday:
                    Console.Write("\t \t \t \t \t");
                    counter = 6;
                    break;
                case DayOfWeek.Sunday:
                    Console.Write("\t \t \t \t \t \t");
                    counter = 7;
                    break;
                default:
                    break;
            }
            for (int i = 1; i < DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++, counter++)
            {
                Console.Write(i + "\t");
                if(counter%7 == 0)
                {
                    Console.WriteLine();
                }
            }
        }
        public void AddEvent(DateTime date, string name)
        {
            Event nEvent = new Event(date, name);
            Events.Add(nEvent);
        }
        public void ShowListEvents()
        {
            foreach (var item in Events)
            {
                Console.WriteLine(item.Datetime + "\t" + item.Name);
            }
        }
        public Organiser()
        {
            Events = new List<Event>();
        }
    }
}

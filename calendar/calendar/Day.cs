using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar
{
    internal class Day
    {
        internal List<CalendarEvent> events;

        DateTime date;
        public DateTime Date { get { return date; } set {   date = value; } }
    }
}

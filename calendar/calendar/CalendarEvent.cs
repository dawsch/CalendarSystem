using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar
{
    internal class CalendarEvent
    {
        uint id;
        DateTime startDate, endDate;
        String title = "No title", note = "";
        Color color;

        internal DateTime StartDate { get { return startDate; } set { startDate = value; } }
        internal DateTime EndDate { get { return endDate; } set { endDate = value; } }
        internal String Title { get { return title; } set { title = value; } }
        internal String Note { get { return note; } set { note = value; } }
        internal Color Color { get { return color; } set { color = value; } }
        internal uint Id { get { return id; } private set { } }

        internal CalendarEvent(uint id, string title, DateTime startDate, DateTime endDate = default, string note = "")
        {
            Id = id;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            Note = note;
            Color = Color.CornflowerBlue;
        }
    }
}

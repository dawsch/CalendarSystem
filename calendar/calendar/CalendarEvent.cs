using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.ComponentModel;

namespace calendar
{
    public class CalendarEvent : INotifyPropertyChanged
    {
        uint id;
        DateTime startDate, endDate;
        String title = "No title", note = "";
        Brush color;

        public DateTime StartDate { get { return startDate; } set { startDate = value; } }
        public DateTime EndDate { get { return endDate; } set { endDate = value; } }
        public String Title { get { return title; } set { title = value; } }
        public String Note { get { return note; } set { note = value; } }
        public Brush Color { get { return color; } set { color = value; OnPropertyChanged(nameof(Color)); } }
        public uint Id { get { return id; } private set { } }

        public CalendarEvent(uint id, string title, DateTime startDate, DateTime endDate = default, string note = "")
        {
            Id = id;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            Note = note;
            Color = new SolidColorBrush(System.Windows.Media.Color.FromRgb(39, 58, 93));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

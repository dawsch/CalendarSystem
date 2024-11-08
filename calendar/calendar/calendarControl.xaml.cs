using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calendar
{
    /// <summary>
    /// Logika interakcji dla klasy calendarControl.xaml
    /// </summary>
    public partial class calendarControl : UserControl
    {
        DateTime actualData;
        public calendarControl()
        {
            InitializeComponent();

            actualData = DateTime.Now;
            int firstDayOfMonty = ((int)new DateTime(actualData.Year, actualData.Month, 1).DayOfWeek) - 1;
            int dayNumber = -firstDayOfMonty + 1;
            int daysOfPrevMonth = DateTime.DaysInMonth(actualData.Year, actualData.Month - 1);

            for (int i = 0; i < 6; i++)
            {
                
                for (int j = 0; j < 7; j++)
                {
                    int offset = 0;
                    TilStatus tailStatus = TilStatus.normal;
                    if (dayNumber <= 0)
                    {
                        offset = daysOfPrevMonth;
                        tailStatus = TilStatus.disable;
                    }
                    if (dayNumber > DateTime.DaysInMonth(actualData.Year, actualData.Month))
                    {
                        offset = -DateTime.DaysInMonth(actualData.Year, actualData.Month);
                        tailStatus = TilStatus.disable;
                    }
                    if (dayNumber == actualData.Day)
                    {
                        tailStatus = TilStatus.today;
                    }
                    customCalendarDayControl day = new customCalendarDayControl(dayNumber + offset, tailStatus);
                    Grid.SetColumn(day, j);
                    Grid.SetRow(day, i);
                    DaysContainer.Children.Add(day);


                    dayNumber++;
                }
            }
        }
    }
}

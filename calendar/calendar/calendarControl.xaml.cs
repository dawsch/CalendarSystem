using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        DateTime actualDate;
        List<customCalendarDayControl> dayControlList;
        public calendarControl()
        {
            InitializeComponent();

            actualDate = DateTime.Now;

            dayControlList = createMonth(actualDate.Year, actualDate.Month);
            foreach (var dayControl in dayControlList)
            {
                DaysContainer.Children.Add(dayControl);
            }
        }

        private void prevClicked(object sender, RoutedEventArgs e)
        {
            actualDate = actualDate.AddMonths(-1);
            updateMonth(actualDate.Year, actualDate.Month, dayControlList);
        }
        private void nextClicked(object sender, RoutedEventArgs e)
        {
            actualDate = actualDate.AddMonths(1);
            updateMonth(actualDate.Year, actualDate.Month, dayControlList);
        }
        void updateMonth(int year, int month, List<customCalendarDayControl> tils)
        {
            int firstDayOfMonty = ((int)new DateTime(year, month, 1).DayOfWeek) - 1;
            int dayNumber = -firstDayOfMonty + 1;
            int daysOfPrevMonth = DateTime.DaysInMonth(year, month - 1);

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
                    if (dayNumber > DateTime.DaysInMonth(year, month))
                    {
                        offset = -DateTime.DaysInMonth(year, month);
                        tailStatus = TilStatus.disable;
                    }
                    if (dayNumber == DateTime.Now.Day)
                    {
                        tailStatus = TilStatus.today;
                    }
                    tils[i * 6 + j].update(dayNumber + offset, tailStatus);

                    dayNumber++;
                }
            }
        }
        List<customCalendarDayControl> createMonth(int year, int month)
        {
            List<customCalendarDayControl> tils = new List<customCalendarDayControl>();

            int firstDayOfMonty = ((int)new DateTime(year, month, 1).DayOfWeek) - 1;
            int dayNumber = -firstDayOfMonty + 1;
            int daysOfPrevMonth = DateTime.DaysInMonth(year, month - 1);

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
                    if (dayNumber > DateTime.DaysInMonth(year, month))
                    {
                        offset = -DateTime.DaysInMonth(year, month);
                        tailStatus = TilStatus.disable;
                    }
                    if (dayNumber == DateTime.Now.Day)
                    {
                        tailStatus = TilStatus.today;
                    }
                    customCalendarDayControl day = new customCalendarDayControl(dayNumber + offset, tailStatus);
                    Grid.SetColumn(day, j);
                    Grid.SetRow(day, i);
                    tils.Add(day);


                    dayNumber++;
                }
            }
            return tils;
        }
    }
}

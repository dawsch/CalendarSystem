﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
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
    internal class calendarInfo : INotifyPropertyChanged
    {
        
        static string[] names = { "styczeń", "luty", "marzec", "kwiecień", "maj", "czerwiec", "lipiec", "sierpień", "wrzesień", "październik", "listopad", "grudzień" };
        private string monthName = "brak";
        private int yearLabel = 0;

        public string MonthName { get { return monthName; } set { if (names.Contains(value)) monthName = value; OnPropertyChanged(nameof(MonthName)); } }
        public int YearLabel { get { return yearLabel; } set { yearLabel = value; OnPropertyChanged(nameof(YearLabel)); } }
        internal calendarInfo(int month, int year)
        {
            MonthName = names[month - 1];
            YearLabel = year;
        }
        internal void setMonth(int month)
        {
            MonthName = names[month - 1];
        }
        internal void setYear(int year)
        {
            YearLabel = year;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public partial class calendarControl : UserControl
    {
        DateTime actualDate { get; set; }
        List<customCalendarDayControl> dayControlList;

        calendarInfo calInfo;
        string actualMonth;

        customCalendarDayControl selectedDay;

        internal EventHandler daySelectedEvent;

        public calendarControl()
        {
            InitializeComponent();
            actualDate = DateTime.Now;

            calInfo = new calendarInfo(actualDate.Month, actualDate.Year);

            this.DataContext = calInfo;


            dayControlList = createMonth(actualDate.Year, actualDate.Month);
            foreach (var dayControl in dayControlList)
            {
                DaysContainer.Children.Add(dayControl);
            }
        }

        private void prevClicked(object sender, RoutedEventArgs e)
        {
            actualDate = actualDate.AddMonths(-1);
            calInfo.setMonth(actualDate.Month);
            calInfo.setYear(actualDate.Year);
            updateMonth(actualDate.Year, actualDate.Month, dayControlList);
        }
        private void nextClicked(object sender, RoutedEventArgs e)
        {
            actualDate = actualDate.AddMonths(1);
            calInfo.setMonth(actualDate.Month);
            calInfo.setYear(actualDate.Year);
            updateMonth(actualDate.Year, actualDate.Month, dayControlList);
        }
        void updateMonth(int year, int month, List<customCalendarDayControl> tils)
        {
            int firstDayOfMontj = getDayOfWeek(new DateTime(year, month, 1));
            int dayNumber = -firstDayOfMontj + 1;
            int daysOfPrevMonth;
            if (month > 1)
                daysOfPrevMonth = DateTime.DaysInMonth(year, month - 1);
            else
                daysOfPrevMonth = DateTime.DaysInMonth(year - 1, 12);
            int index = 0;

            int DaysInMonty_year_month = DateTime.DaysInMonth(year, month);

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
                    if (dayNumber > DaysInMonty_year_month)
                    {
                        offset = -DaysInMonty_year_month;
                        tailStatus = TilStatus.disable;
                    }
                    if (dayNumber == DateTime.Today.Day && year == DateTime.Today.Year && month == DateTime.Today.Month)
                    {
                        tailStatus = TilStatus.today;
                    }
                    tils[index].update(new DateTime(year, month, dayNumber + offset), tailStatus);

                    dayNumber++;
                    index++;
                }
            }
        }
        List<customCalendarDayControl> createMonth(int year, int month)
        {
            List<customCalendarDayControl> tils = new List<customCalendarDayControl>();
            Random rnd = new Random();
            int firstDayOfMonty = getDayOfWeek(new DateTime(year, month, 1));
            int dayNumber = -firstDayOfMonty + 1;
            int daysOfPrevMonth;
            if (month > 1)
                daysOfPrevMonth = DateTime.DaysInMonth(year, month - 1);
            else
                daysOfPrevMonth = DateTime.DaysInMonth(year - 1, 12);

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
                    if (dayNumber == DateTime.Today.Day && year == DateTime.Today.Year && month == DateTime.Today.Month)
                    {
                        tailStatus = TilStatus.today;
                    }
                    customCalendarDayControl day = new customCalendarDayControl(new DateTime(year, month, dayNumber + offset), tailStatus);
                    int count = rnd.Next(0, 4);
                    for (int k = 0; k <= count; k++)
                    {
                        day.events.Add(new CalendarEvent((uint)(i * j + j), "tytuł", DateTime.Now));
                        day.events[day.events.Count - 1].Note = "testowa notatka, teścik, testowy";
                        day.events[day.events.Count - 1].Color = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255)));
                    }
                    day.clikcked += OnDaySelected;
                    Grid.SetColumn(day, j);
                    Grid.SetRow(day, i);
                    tils.Add(day);


                    dayNumber++;
                }
            }
            return tils;
        }

        void OnDaySelected(object sender, EventArgs e)
        {
            selectedDay?.disable();
            selectedDay = (customCalendarDayControl)sender;
            selectedDay.setAsSelected();

            daySelectedEvent?.Invoke(selectedDay, e);
        }

        static int getDayOfWeek(DateTime date)
        {
            int result = (int)date.DayOfWeek;
            if (result == 0)
                return 6;

            return result - 1;
        }

        
    }
}

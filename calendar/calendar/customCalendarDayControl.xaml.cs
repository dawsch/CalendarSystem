using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public enum TilStatus
    {
        normal,
        disable,
        active,
        today
    }
    public partial class customCalendarDayControl : UserControl, INotifyPropertyChanged
    {
        internal EventHandler clikcked;
        private bool isToday = false;
        TilStatus status;
        public int DayNumber { get { return dayNumber; } set { if (value > 0 && value <= 31) { dayNumber = value; OnPropertyChanged(nameof(DayNumber)); } } }
        int dayNumber;
        Brush textColor;
        public Brush TextColor { get { return textColor; } set { textColor = value; OnPropertyChanged(nameof(TextColor)); } }

        public ObservableCollection<CalendarEvent> events
        {
            get { return (ObservableCollection<CalendarEvent>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty ItemsProperty =
        DependencyProperty.Register("events", typeof(ObservableCollection<CalendarEvent>), typeof(customCalendarDayControl), new PropertyMetadata(null));

        public customCalendarDayControl()
        {
            InitializeComponent();
            this.DataContext = this;
            
        }
        public customCalendarDayControl(int _dayNumber = 0, TilStatus _status = TilStatus.normal)
        {
            status = _status;
            if (status == TilStatus.today)
                isToday = true;
            DayNumber = _dayNumber;
            events = new ObservableCollection<CalendarEvent>();
            //DayNumberLabel.Content = dayNumber;
            InitializeComponent();
            this.DataContext = this;

            TileBorder.BorderBrush = getBorderColor();
            TileBorder.Background = getBackColor();

            if (status == TilStatus.normal || status == TilStatus.today || status == TilStatus.active)
            {
                TextColor = (Brush)Application.Current.Resources["NormaleDayTextBrush"];
            }
            else
            { 
                TextColor = (Brush)Application.Current.Resources["DisableDayTextBrush"];
            }

            //events.Add(new CalendarEvent(1, "test", DateTime.Now));
            //events.Add(new CalendarEvent(2, "test", DateTime.Now));
            //events[1].Color = new SolidColorBrush(Color.FromRgb(212, 241, 80));
            //events.Add(new CalendarEvent(3, "test", DateTime.Now));
            //eventListControl.ItemsSource = events;

        }

        private void TileBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            TileBorder.Background = (Brush)FindResource("HoverButtonBrush");
        }

        private void TileBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            TileBorder.Background = getBackColor();
        }
        private Brush getBackColor()
        {

            if (status == TilStatus.today)
            {
                return (Brush)FindResource("TodayTileBrush");
            }
            if (status == TilStatus.active)
            {
                return (Brush)FindResource("ActiveTileBrush");
            }
            return (Brush)FindResource("PrimaryBrush");
        }
        private Brush getBorderColor()
        {
            //if (status == TilStatus.disable)
            //{
            //    return Brushes.Lavender;
            //}
            return Brushes.Transparent;
        }
        public void update(int _dayNumber, TilStatus _status)
        {
            status = _status;
            DayNumber = _dayNumber;

            TileBorder.Background = getBackColor();
            TileBorder.BorderBrush = getBorderColor();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        bool pressed = false;
        private void TileBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            pressed = true;
        }
        private void TileBorder_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (pressed)
            {
                Console.WriteLine("clicked");
                pressed = false;
                clikcked?.Invoke(this, EventArgs.Empty);
            }
        }
        internal void setAsSelected()
        {
            status = TilStatus.active;
            TileBorder.Background = getBackColor();
        }
        internal void disable()
        {
            if (isToday)
                status = TilStatus.today;
            else
                status = TilStatus.normal;
            TileBorder.Background = getBackColor();
        }
    }
}
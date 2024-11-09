using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        TilStatus status;
        public int DayNumber { get { return dayNumber; } set { if (value > 0 && value <= 31) { dayNumber = value; OnPropertyChanged(nameof(DayNumber)); } } }
        int dayNumber;
        public customCalendarDayControl()
        {
            InitializeComponent();
            this.DataContext = this;
            
        }
        public customCalendarDayControl(int _dayNumber = 0, TilStatus _status = TilStatus.normal)
        {
            status = _status;
            DayNumber = _dayNumber;
            InitializeComponent();
            this.DataContext = this;
            //DayNumberLabel.Content = dayNumber;

            TileBorder.BorderBrush = getBorderColor();
            TileBorder.Background = getBackColor();
        }

        private void TileBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            TileBorder.Background = new SolidColorBrush(Colors.LightGray);
        }

        private void TileBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            TileBorder.Background = getBackColor();
        }
        private Brush getBackColor()
        {

            if (status == TilStatus.today)
            {
                return Brushes.Beige;
            }
            return Brushes.White;
        }
        private Brush getBorderColor()
        {
            if (status == TilStatus.disable)
            {
                return Brushes.Lavender;
            }
            return Brushes.Red;
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
    }
}

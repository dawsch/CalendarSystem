﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Logika interakcji dla klasy dayEventList.xaml
    /// </summary>
    public partial class dayEventList : UserControl
    {
        internal customCalendarDayControl dayControl;
        public dayEventList()
        {
            InitializeComponent();
        }
        internal void OnDaySelected(object sender, EventArgs e)
        {
            dayControl = (customCalendarDayControl)sender;
            DataContext = dayControl;
            
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            
        }

    }
}

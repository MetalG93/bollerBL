﻿using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace bollerBL
{
    /// <summary>
    /// Interaction logic for showGuests.xaml
    /// </summary>
    public partial class showGuests : Window
    {
        public showGuests()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Misc.saveGuests();
        }

        private void btnGuestDelete(object sender, RoutedEventArgs e)
        {
            Misc.guests.Remove((Guest)((Button)e.OriginalSource).DataContext);
        }
    }
}

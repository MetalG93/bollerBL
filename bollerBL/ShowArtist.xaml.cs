using System;
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
using Xceed.Wpf.Toolkit;

namespace bollerBL
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ShowArtist : Window
    {
        public ShowArtist()
        {
            Misc.loadArtist();
            InitializeComponent();
        }

        private void ShowArtist_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
        }

        private void ShowArtist_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Misc.saveArtist();
        }

        private void TimePicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            
        }
    }
}

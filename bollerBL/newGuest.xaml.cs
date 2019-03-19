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

namespace bollerBL
{
    /// <summary>
    /// Interaction logic for newGuest.xaml
    /// </summary>
    public partial class newGuest : Window
    {
        public newGuest()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Misc.guests.Add(new Guest(txtName.Text, txtPhoneNumber.Text, txtEmail.Text, (bool)chxWillCome.IsChecked));
            Misc.saveGuests();
        }
    }
}

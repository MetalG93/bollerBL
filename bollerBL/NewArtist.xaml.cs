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
    /// Interaction logic for NewArtist.xaml
    /// </summary>
    public partial class NewArtist : Window
    {
        string message = "";
        public NewArtist()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (everythingOk())
            {
                Misc.artists.Add(new Artist(txtArtistName.Text, txtContactName.Text, txtContactPhone.Text, txtContactMail.Text, int.Parse(txtFee.Text), DateTime.Parse(txtShowBegin.Text), new TimeSpan(int.Parse(txtShowLengthHour.Text), int.Parse(txtShowLengthMinutes.Text), 0)));
                Misc.saveArtist();
            }
            else
                MessageBox.Show(message);
        }

        private bool everythingOk()
        {
            bool ret = true;

            if (txtArtistName.Text == "")
            {
                ret = false;
                message += "A fellépő neve nem lehet üres!" + Environment.NewLine;
            }

            if (txtContactName.Text == "")
            {
                ret = false;
                message += "A kapcsolattartó neve nem lehet üres!" + Environment.NewLine;
            }

            if (txtContactPhone.Text == "")
            {
                ret = false;
                message += "A kapcsolattartó telefonszáma nem lehet üres!" + Environment.NewLine;
            }

            if (txtContactMail.Text == "")
            {
                ret = false;
                message += "A kapcsolattartó e-mail címe nem lehet üres!" + Environment.NewLine;
            }

            return ret;
        }
    }
}

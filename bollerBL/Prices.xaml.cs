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
    /// Interaction logic for Prices.xaml
    /// </summary>
    public partial class Prices : Window
    {
        public Prices()
        {
            InitializeComponent();
            Misc.loadPrices();
            txtAdultPrice.Text = Misc.adultPrice.ToString();
            txtChildrenPrice.Text = Misc.childrenPrice.ToString();
            txtTasteTicketPrice.Text = Misc.taseTicketPrice.ToString();
            txtRafflePrice.Text = Misc.rafflePrice.ToString();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Misc.adultPrice = int.Parse(txtAdultPrice.Text);
            Misc.childrenPrice = int.Parse(txtChildrenPrice.Text);
            Misc.taseTicketPrice = int.Parse(txtTasteTicketPrice.Text);
            Misc.rafflePrice = int.Parse(txtRafflePrice.Text);
            Misc.savePrices();
        }
    }
}

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
    /// Interaction logic for Choose.xaml
    /// </summary>
    public partial class Choose : Window
    {
        public Choose()
        {
            InitializeComponent();
        }

        private void mniLogoff_Click(object sender, RoutedEventArgs e)
        {
            Login li = new Login();
            li.Show();
            this.Close();
        }

        private void btnGateFinancial_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GateFinancial gf = new GateFinancial();
                gf.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nem tudtam megnyitni az ablakot!" + Environment.NewLine + ex.Message);
                Misc.logging("GateFinancial " + ex.Message);
            }
        }

        private void btnCustonPlantNum_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtPlateNum.Text != "")
                    Misc.createEntryPermit(txtPlateNum.Text.ToUpper());
                else
                    MessageBox.Show("Adjon meg rendszámot!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nem tudtam megnyitni az ablakot!" + Environment.NewLine + ex.Message);
                Misc.logging("GateFinancial " + ex.Message);
            }
        }

        private void mniNewTeam(object sender, RoutedEventArgs e)
        {
            try
            {
                NewTeam nt = new NewTeam();
                nt.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nem tudtam megnyitni az ablakot!" + Environment.NewLine + ex.Message);
                Misc.logging("NewTeam " + ex.Message);
            }
        }

        private void mniEditTeam(object sender, RoutedEventArgs e)
        {
            try
            {
                ShowTeams st = new ShowTeams();
                st.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nem tudtam megnyitni az ablakot!" + Environment.NewLine + ex.Message);
                Misc.logging("ShowTeams " + ex.Message);
            }
        }

        private void mniNewArtist(object sender, RoutedEventArgs e)
        {
            try
            {
                NewArtist na = new NewArtist();
                na.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nem tudtam megnyitni az ablakot!" + Environment.NewLine + ex.Message);
                Misc.logging("NewArtist " + ex.Message);
            }
        }

        private void mniEditArtist(object sender, RoutedEventArgs e)
        {
            try
            {
                ShowArtist sa = new ShowArtist();
                sa.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nem tudtam megnyitni az ablakot!" + Environment.NewLine + ex.Message);
                Misc.logging("ShowArtist " + ex.Message);
            }
        }

        private void mniArtistTimeLine(object sender, RoutedEventArgs e)
        {
            try
            {
                Timeline tl = new Timeline();
                tl.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nem tudtam megnyitni az ablakot!" + Environment.NewLine + ex.Message);
                Misc.logging("Timeline " + ex.Message);
            }
        }

        private void mniChangePrice(object sender, RoutedEventArgs e)
        {
            try
            {
                Prices p = new Prices();
                p.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nem tudtam megnyitni az ablakot!" + Environment.NewLine + ex.Message);
                Misc.logging("Prices " + ex.Message);
            }
        }

        private void mniNewGuest(object sender, RoutedEventArgs e)
        {
            newGuest ng = new newGuest();
            ng.Show();
        }

        private void mniEditGuest(object sender, RoutedEventArgs e)
        {
            showGuests sg = new showGuests();
            sg.Show();
        }

        private void btnOpenPdfContainer(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Misc.PDFpath);
        }

        private void mniNewUser_Click(object sender, RoutedEventArgs e)
        {
            NewUser nu = new NewUser();
            nu.Show();
        }

        private void mniEditUser_Click(object sender, RoutedEventArgs e)
        {
            EditUser eu = new EditUser();
            eu.Show();
        }

        private void mniDeleteTeams(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Biztos törölni akarod a csapatokat? A törlés nem visszavonható!", "Csapatok törlése", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Misc.teams.Clear();
                Misc.saveTeams();
            }
        }

        private void mniDeleteArtists(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Biztos törölni akarod a fellépőket? A törlés nem visszavonható!", "Fellépők törlése", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Misc.artists.Clear();
                Misc.saveArtist();
            }
        }

        private void mniDeleteGuests(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Biztos törölni akarod a vendégeket? A törlés nem visszavonható!", "Vendégek törlése", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Misc.guests.Clear();
                Misc.saveGuests();
            }
        }
    }
}

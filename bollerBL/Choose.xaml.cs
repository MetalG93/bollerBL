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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GateFinancial gf = new GateFinancial();
            gf.Show();
        }

        private void mniNewTeam(object sender, RoutedEventArgs e)
        {
            NewTeam nt = new NewTeam();
            nt.Show();
        }

        private void mniEditTeam(object sender, RoutedEventArgs e)
        {
            ShowTeams st = new ShowTeams();
            st.Show();
        }
    }
}

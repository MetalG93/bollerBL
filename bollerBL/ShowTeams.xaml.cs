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
    /// Interaction logic for ShowTeams.xaml
    /// </summary>
    public partial class ShowTeams : Window
    {
        public ShowTeams()
        {
            InitializeComponent();
            Misc.loadTeams();
        }

        private void Datagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            EditTeam et = new EditTeam(1);
            et.Show();
        }

        private void ShowTeams_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Misc.saveTeams();
        }

        private void btnEntryPermission_Click(object sender, RoutedEventArgs e)
        {
            Team team = (Team)datagrid.SelectedItem;
            team.createEntryPermit();
        }

        private void btnDeleteTeam_Click(object sender, RoutedEventArgs e)
        {
            Misc.teams.Remove((Team)datagrid.SelectedItem);
        }

        private void btnTeamDelete(object sender, RoutedEventArgs e)
        {
            Misc.teams.Remove((Team)((Button)e.OriginalSource).DataContext);
        }
    }
}

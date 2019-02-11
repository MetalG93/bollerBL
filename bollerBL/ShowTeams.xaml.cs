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
            //datagrid.ItemsSource = Misc.teams;
            Misc.loadTeams();
            colWidth();
        }

        private void ShowTeams_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            colWidth();
        }

        private void colWidth()
        {
            //double width=this.Width/
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
    }
}

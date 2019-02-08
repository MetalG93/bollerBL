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
    /// Interaction logic for NewTeam.xaml
    /// </summary>
    public partial class NewTeam : Window
    {

        public NewTeam()
        {
            InitializeComponent();
            placeUI();
        }

        private void placeUI()
        {
            double height = (this.Height - 25) / 8;
            double width = (this.Width - 30) / 2;

            foreach (Grid g in sPanel.Children)
            {
                if (g.Children.Count > 1)
                {
                    g.Height = height;
                    g.Width = this.Width;

                    ((Label)g.Children[0]).Width = width;

                    if (object.Equals(g.Children[1].GetType(), typeof(TextBox)))
                        ((TextBox)g.Children[1]).Width = width;

                    ((FrameworkElement)g.Children[1]).Margin = new Thickness(width + 20, 0, 0, 0);
                }
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            placeUI();
        }
    }
}

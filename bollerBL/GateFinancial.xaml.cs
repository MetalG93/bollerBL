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
    /// Interaction logic for GateFinancial.xaml
    /// </summary>
    public partial class GateFinancial : Window
    {
        public GateFinancial()
        {
            InitializeComponent();
        }

        private void BtnNewBox_Click(object sender, RoutedEventArgs e)
        {
            if (cbxBoxType.SelectedIndex != -1)
            {
                GroupBox gb = new GroupBox();

                if (cbxBoxType.SelectedIndex == 0)
                {
                    gb.Header = "Felnőtt jegyek";
                }
                else
                {
                    gb.Header = "Gyerek jegyek";
                }

                Grid g = new Grid();
                Label label1 = new Label();
                label1.Content = "Kezdő sorszám";
                label1.Margin = new Thickness(10, 10, 0, 0);

                TextBox txtBegin = new TextBox();
                txtBegin.Margin = new Thickness(120, 10, 0, 0);

                Label label2 = new Label();
                label2.Content = "Vége sorszám";
                label2.Margin = new Thickness(230, 10, 0, 0);

                TextBox txtEnd= new TextBox();
                txtEnd.Margin = new Thickness(340, 10, 0, 0);

                Button btnDelete = new Button();
                btnDelete.HorizontalAlignment = HorizontalAlignment.Left;
                btnDelete.VerticalAlignment = VerticalAlignment.Top;
                btnDelete.Margin = new Thickness(450, 10, 0, 0);
                btnDelete.Content = "Doboz törlése";
                btnDelete.Width = 100;
                btnDelete.Height = 25;
                btnDelete.Click += btnDelete_Click;

                g.Children.Add(label1);
                g.Children.Add(txtBegin);
                g.Children.Add(label2);
                g.Children.Add(txtEnd);
                g.Children.Add(btnDelete);
                gb.Content = g;
                ticketBoxes.Children.Add(gb);
            }
            else
                MessageBox.Show("Válassz ki doboz típust!");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ticketBoxes.Children.Remove((GroupBox)((Grid)(((Button)e.OriginalSource).Parent)).Parent);
        }

        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            decimal children = 0;
            decimal adult = 0;

            foreach (GroupBox gb in ticketBoxes.Children)
            {
                Grid g = (Grid)gb.Content;

                    if (gb.Header.ToString() == "Felnőtt jegyek")
                        adult += decimal.Parse(((TextBox)g.Children[3]).Text) - decimal.Parse(((TextBox)g.Children[1]).Text);
                    else
                        children += decimal.Parse(((TextBox)g.Children[3]).Text) - decimal.Parse(((TextBox)g.Children[1]).Text);
            }

            int money = 0;

            for (int i = 1; i < sMoney.Children.Count; i++)
            {
                money += int.Parse(((TextBox)((Grid)sMoney.Children[i]).Children[1]).Text) * int.Parse(((Label)((Grid)sMoney.Children[i]).Children[0]).Content.ToString());
            }

            MessageBox.Show(string.Format("Összes pénz: {0}{1}Hozott pénz: {2}", children * Misc.childrenPrice + adult * Misc.adultPrice, Environment.NewLine, money));
        }
    }
}

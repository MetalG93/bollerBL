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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            SplashScreen sc = new SplashScreen("ikon.png");
            sc.Show(false);

            Misc.loadUsers();

            sc.Close(new TimeSpan(0, 0, 1));
            InitializeComponent();
            placeUI();
            cmbUser.ItemsSource = Misc.users;
            cmbUser.DisplayMemberPath = "Name";

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            login();
        }

        private void placeUI()
        {
            double width = this.Width / 25;
            double height = this.Height / 10;

            lblUser.Margin = new Thickness(width, 2 * height, 0, 0);
            lblUser.Width = 10 * width;
            lblUser.Height = height;

            cmbUser.Margin = new Thickness(12 * width, 2 * height, 0, 0);
            cmbUser.Width = 10 * width;
            cmbUser.Height = height;

            lblPass.Margin = new Thickness(width, 4 * height, 0, 0);
            lblPass.Width = 10 * width;
            lblPass.Height = height;

            pswPass.Margin = new Thickness(12 * width, 4 * height, 0, 0);
            pswPass.Width = 10 * width;
            pswPass.Height = height;

            btnLogin.Margin = new Thickness(6 * width, 6 * height, 0, 0);
            btnLogin.Width = 11 * width;
            btnLogin.Height = height;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            placeUI();
        }

        private void PswPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                login();
        }

        private void login()
        {
            if (pswPass.Password == Misc.users[cmbUser.SelectedIndex].PassWord)
            {
                Misc.logging("Bejelentkezés: " + Misc.users[cmbUser.SelectedIndex].Name);
                Choose ch = new Choose();
                ch.Show();
                this.Close();
            }
            else
                MessageBox.Show("Jelszó nem megfelelő!");
        }
    }
}
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
            if (Misc.firstStart)
            {
                SplashScreen sc = new SplashScreen("ikon.png");
                sc.Show(false);
                sc.Close(new TimeSpan(0, 0, 1));
            }

            Misc.loadUsers();

            InitializeComponent();
            cmbUser.ItemsSource = Misc.users;
            cmbUser.DisplayMemberPath = "Name";

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            login();
        }

        private void PswPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                login();
        }

        private void login()
        {
            if (Misc.CalculateMD5(pswPass.Password) == Misc.users[cmbUser.SelectedIndex].PassWord)
            {
                Misc.logging("Bejelentkezés: " + Misc.users[cmbUser.SelectedIndex].Name);
                Choose ch = new Choose();
                ch.Show();
                Misc.firstStart = false;
                this.Close();
            }
            else
                MessageBox.Show("Jelszó nem megfelelő!");
        }
    }
}
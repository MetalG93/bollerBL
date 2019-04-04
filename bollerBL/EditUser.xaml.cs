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
    /// Interaction logic for EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        public EditUser()
        {
            InitializeComponent();
            txtName.ItemsSource = Misc.users;
            txtName.DisplayMemberPath = "Name";
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (txtPassOld.Password.Length > 0)
            {
                if (txtPassNew.Password == txtPassNewAgain.Password)
                {
                    Misc.users[txtName.SelectedIndex].PassWord = Misc.CalculateMD5(txtPassNew.Password);
                    Misc.saveUsers();
                }
            }
        }
    }
}

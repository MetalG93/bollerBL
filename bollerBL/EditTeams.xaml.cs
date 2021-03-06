﻿using System;
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
using System.Text.RegularExpressions;

namespace bollerBL
{
    /// <summary>
    /// Interaction logic for NewTeam.xaml
    /// </summary>
    public partial class EditTeam : Window
    {

        public EditTeam(int index)
        {
            InitializeComponent();
            placeUI();
            fillDatas(index);
        }

        private void fillDatas(int index)
        {
            /*int i = 0;
            while (i < Misc.teams.Count && Misc.teams[i].Index != index)
                i++;

            txtTemNAme.Text = Misc.teams[i].Name;
            txtLeaderName.Text = Misc.teams[i].Leader;
            txtPhoneNumber.Text = Misc.teams[i].Phone;
            txtEmail.Text = Misc.teams[i].Email;
            txtAddress.Text = Misc.teams[i].Address;
            txtNumber.Text = Misc.teams[i].Number.ToString();
            chxPaid.IsChecked = Misc.teams[i].Paid;*/
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

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (everythingOk())
            {
                Misc.teams.Add(new Team(txtTemNAme.Text, txtLeaderName.Text, txtPhoneNumber.Text, txtEmail.Text, txtAddress.Text, int.Parse(txtNumber.Text), (bool)chxPaid.IsChecked));
                Misc.saveTeams();
            }
            else
                MessageBox.Show(message, "Hiányzó adatok");
        }

        string message;
        private bool everythingOk()
        {
            bool ok = true;

            if (txtTemNAme.Text == "")
            {
                ok = false;
                message += "Nincs kitöltve a csapatnév" + Environment.NewLine;
            }

            if (txtLeaderName.Text == "")
            {
                ok = false;
                message += "Nincs kitöltve a csapatvezető neve" + Environment.NewLine;
            }

            if (txtPhoneNumber.Text == "")
            {
                ok = false;
                message += "Nincs kitöltve a csapatvezető telefonszáma" + Environment.NewLine;
            }

            if (txtEmail.Text == "")
            {
                ok = false;
                message += "Nincs kitöltve a csapatvezető e-mail címe" + Environment.NewLine;
            }

            return ok;
        }
    }
}

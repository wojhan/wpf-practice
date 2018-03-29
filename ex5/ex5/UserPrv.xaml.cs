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

namespace ex5
{
    /// <summary>
    /// Logika interakcji dla klasy UserPrv.xaml
    /// </summary>
    public partial class UserPrv : Window
    {
        public User SelectedUser { get; set; }

        public UserPrv()
        {
            InitializeComponent();
        }

        public void LoadUser()
        {
            if (SelectedUser != null)
            {
                firstNameInput.Text = SelectedUser.FirstName;
                lastNameInput.Text = SelectedUser.LastName;
                emailInput.Text = SelectedUser.Email;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUser();
        }

        private void firstNameInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            SelectedUser.FirstName = firstNameInput.Text;

            ((MainWindow)Application.Current.MainWindow).UpdateUsers();
            ((MainWindow)Application.Current.MainWindow).UpdatePreview();
        }

        private void lastNameInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            SelectedUser.LastName = lastNameInput.Text;

            ((MainWindow)Application.Current.MainWindow).UpdateUsers();
            ((MainWindow)Application.Current.MainWindow).UpdatePreview();
        }

        private void emailInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                SelectedUser.Email = emailInput.Text;
            }catch(FormatException) { }

            ((MainWindow)Application.Current.MainWindow).UpdateUsers();
            ((MainWindow)Application.Current.MainWindow).UpdatePreview();
        }
    }
}

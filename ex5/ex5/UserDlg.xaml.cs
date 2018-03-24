using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Logika interakcji dla klasy UserDlg.xaml
    /// </summary>
    public partial class UserDlg : Window
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public UserDlg()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            FirstName = firstNameInput.Text;
            LastName = lastNameInput.Text;
            Email = emailInput.Text;

            if (new EmailAddressAttribute().IsValid(Email))
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Błędny adres E-mail.");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            firstNameInput.Text = FirstName;
            lastNameInput.Text = LastName;
            emailInput.Text = Email;
        }
    }
}

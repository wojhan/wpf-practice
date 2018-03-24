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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ex5
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UpdateUser(User user, string firstName, string lastName, string email)
        {
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            UserDlg dlg = new UserDlg();
            if(dlg.ShowDialog() == true)
            {
                User user = new User
                {
                    FirstName = dlg.FirstName,
                    LastName = dlg.LastName,
                    Email = dlg.Email
                };
                usersList.Items.Add(user);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            User user = usersList.SelectedItem as User;

            if(user != null)
            {
                UserDlg dlg = new UserDlg();
                dlg.FirstName = user.FirstName;
                dlg.LastName = user.LastName;
                dlg.Email = user.Email;

                if (dlg.ShowDialog() == true)
                {
                    UpdateUser(user, dlg.FirstName, dlg.LastName, dlg.Email);
                    usersList.Items.Refresh();
                }
            }
        }
    }
}

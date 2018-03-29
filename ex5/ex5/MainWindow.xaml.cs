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
        private List<UserPrv> prv;
        private User selectedUser;

        public MainWindow()
        {
            InitializeComponent();

            selectedUser = usersList.SelectedItem as User;
            prv = new List<UserPrv>();

            editButton.IsEnabled = false;
            removeButton.IsEnabled = false;
            previewButton.IsEnabled = false;
        }

        public void UpdateUser(User user, string firstName, string lastName, string email)
        {
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            UpdateUsers();
        }

        public void UpdateUsers()
        {
            usersList.Items.Refresh();
        }

        public void UpdatePreview()
        {
            foreach (UserPrv userPrv in prv)
            {
                if (selectedUser != null)
                {
                    userPrv.SelectedUser = selectedUser;
                    userPrv.LoadUser();
                }
            }
        }

        private void closePreviews()
        {
            foreach (UserPrv userPrv in prv)
            {
                userPrv.Close();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            UserDlg dlg = new UserDlg();
            if (dlg.ShowDialog() == true)
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
            UserDlg dlg = new UserDlg();
            dlg.FirstName = selectedUser.FirstName;
            dlg.LastName = selectedUser.LastName;
            dlg.Email = selectedUser.Email;

            if (dlg.ShowDialog() == true)
            {
                UpdateUser(selectedUser, dlg.FirstName, dlg.LastName, dlg.Email);
                UpdatePreview();
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Czy na pewno chcesz usunąć użytkownika\n" + selectedUser.FirstName + " " + selectedUser.LastName + "?", "Usuwanie użytkownika", 
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                usersList.Items.Remove(selectedUser);
                closePreviews();
                selectedUser = null;
            }
        }

        private void UsersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedUser = usersList.SelectedItem as User;

            if (selectedUser == null)
            {
                editButton.IsEnabled = false;
                removeButton.IsEnabled = false;
                previewButton.IsEnabled = false;
            }
            else
            {
                editButton.IsEnabled = true;
                removeButton.IsEnabled = true;
                previewButton.IsEnabled = true;
            }
            UpdatePreview();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PreviewButton_Click(object sender, RoutedEventArgs e)
        {
            UserPrv userPrv = new UserPrv();
            prv.Add(userPrv);
            userPrv.SelectedUser = selectedUser;
            userPrv.LoadUser();
            userPrv.Show();
        }
    }
}

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

namespace ex7
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            usersList.ItemsSource = UserManager.Instance.Users;
            Location.ItemsSource = Enum.GetValues(typeof(LocationEnum)).Cast<LocationEnum>();
            usersList.DisplayMemberPath = "Desc";
        }

        private void DetailsCheckbox_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MessageBox.Show("test");
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            User user = new User();
            UserManager.Instance.Users.Add(user);
            usersList.SelectedIndex = usersList.Items.Count - 1;
        }

        private void DeleteUser_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(usersList.SelectedItem != null)
            {
                e.CanExecute = true;
            }
        }

        private void DeleteUser_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int index = usersList.SelectedIndex;
            UserManager.Instance.Users.RemoveAt(index);
            usersList.SelectedIndex = index - 1;
        }

        private void usersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(usersList.SelectedItem != null)
            {
                
            }
        }
    }
}

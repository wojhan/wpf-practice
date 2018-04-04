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
            string test = "dodaj nową osobę...";
            UserManager.Instance.Users.Add(test);
            //ListBoxItem addUser = usersList.ItemsSourc
            ListBoxItem addUser = (ListBoxItem)(usersList.ItemContainerGenerator.ContainerFromIndex(0));

            CommandBinding addUserBind = new CommandBinding();
            addUserBind.Command = UserCommands.AddUser;
            //addUser.CommandBindings.Add(addUserBind);

            //usersList.Items.Add((new ListBoxItem()).Content = "Dodaj nową osobę...");
        }

        private void usersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = usersList.SelectedIndex;
            
            if(index != UserManager.Instance.Users.Count - 1)
            {
                FirstNameInput.Text = UserManager.Instance.GetUser(index).FirstName;
                SurnameInput.Text = UserManager.Instance.GetUser(index).Surname;
                EmailInput.Text = UserManager.Instance.GetUser(index).Email;
            }
                
        }

        private void AddUser_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("test");
        }

        private void AddUser_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}

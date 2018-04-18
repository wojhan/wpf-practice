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

namespace ex6
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ListBoxItem tmp;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PickUp_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Parameter is ListBox list)
            {
                if (Temp.Text == "" && list.HasItems)
                {
                    e.CanExecute = true;
                }
            }
        }

        private void PickUp_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ListBox list = e.Parameter as ListBox;
            ListBoxItem item = (ListBoxItem)list.Items[0];
            tmp = item;
            list.Items.Remove(item);
            Temp.Text = item.Content.ToString();
        }

        private void PutDown_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Parameter is ListBox list && Temp.Text != "")
            {
                if (!list.HasItems)
                {
                    e.CanExecute = true;
                }
                else
                {
                    ListBoxItem item = (ListBoxItem)list.Items[0];

                    if (Int32.Parse(Temp.Text) < Int32.Parse(item.Content.ToString()))
                    {
                        e.CanExecute = true;
                    }
                }
            }
        }

        private void PutDown_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ListBox list = e.Parameter as ListBox;
            list.Items.Insert(0,tmp);
            tmp = null;
            Temp.Text = "";
        }
    }
}

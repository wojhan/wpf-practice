using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ex6
{
    public class HanoiCommands
    {
        private static RoutedUICommand pickUp;
        private static RoutedUICommand putDown;

        static HanoiCommands()
        {
            pickUp = new RoutedUICommand("Pick an item up", "PickUp", typeof(HanoiCommands));
            putDown = new RoutedUICommand("Put an item down", "PutDown", typeof(HanoiCommands));
        }

        public static RoutedUICommand PickUp
        {
            get { return pickUp; }
        }

        public static RoutedUICommand PutDown
        {
            get { return putDown; }
        }
    }
}

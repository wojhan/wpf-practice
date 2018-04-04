using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ex7
{
    public class UserCommands
    {
        private static RoutedUICommand addUser;
        static UserCommands()
        {
            addUser = new RoutedUICommand(
                "Add new user", "AddUser", typeof(UserCommands));

            //addUser.InputGestures.Add(new MouseGesture(MouseAction.LeftClick));
        }
        public static RoutedUICommand AddUser
        {
            get { return addUser; }
        }
    }
}

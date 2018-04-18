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
        private static RoutedUICommand deleteUser;
        static UserCommands()
        {
            deleteUser = new RoutedUICommand(
                "Delete a user", "DeleteUser", typeof(UserCommands));

            //addUser.InputGestures.Add(new MouseGesture(MouseAction.LeftClick));
        }
        public static RoutedUICommand DeleteUser
        {
            get { return deleteUser; }
        }
    }
}

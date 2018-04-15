using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex7
{
    public class User : INotifyPropertyChanged
    {
        private string firstname;
        private string surname;
        private string email;
        private bool details;

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
                OnPropertyChanged("");
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyChanged("");
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged("");
            }
        }

        public bool Details
        {
            get
            {
                return details;
            }
            set
            {
                details = value;
                OnPropertyChanged("");
            }
        }

        public string Desc
        {
            get
            {
                if (details)
                    return firstname + " " + surname + " (" + email + ")";
                else
                    return firstname + " " + surname;
            }
        }

        public decimal Payment { get; set; }
        public int AccessLevel { get; set; }
        public LocationEnum Location { get; set; }

        //private Location loc;
        public bool IsDetailsChecked { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public User()
        {
            IsDetailsChecked = false;
            Payment = 0;
            AccessLevel = 0;
        }

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public override string ToString()
        {
            return Firstname + " " + Surname + " (" + Email + ")";
        }

    }

    public class UserManager
    {
        private ObservableCollection<User> users = new ObservableCollection<User>();
        public User GetUser(int id)
        {
            return users[id];
        }
        private UserManager()
        {
            users.Add(new User() { Firstname = "Jan", Surname = "Kowalski", Email = "jan@kowalski.pl", IsDetailsChecked = false });
        }
        private static UserManager singleton = null;
        public static UserManager Instance
        {
            get
            {
                if (singleton == null)
                    singleton = new UserManager();
                return singleton;
            }
        }
        public ObservableCollection<User> Users
        {
            get
            {
                return users;
            }
        }
    }
}

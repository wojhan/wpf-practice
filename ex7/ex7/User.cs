using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex7
{
    public class User
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        private decimal payment;
        private int accessLevel;
        private Location loc;
        private bool test;

        public User(bool _test = false)
        {
            test = _test;
            payment = 0;
            accessLevel = 0;
        }

        public override string ToString()
        {
            if (test)
            {
                return "Dodaj nową osobę...";
            }
            else
            {
                return FirstName + " " + Surname + " (" + Email + ")";
            }
        }

    }

    public class UserManager
    {
        private List<object> users = new List<object>();
        public User GetUser(int id)
        {
            if (id < users.Count - 1)
                return (User)users[id];
            else
                return null;
        }
        public UserManager()
        {
            users.Add("dodaj nową osobę...");
            users.Insert(0, new User() { FirstName = "Jan", Surname = "Kowalski", Email = "jan@kowalski.pl" });
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
        public List<object> Users
        {
            get
            {
                return users;
            }
        }
    }
}

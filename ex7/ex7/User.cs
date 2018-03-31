using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex7
{
    public class User
    {
        private string firstName, surname, email;
        private decimal payment;
        private int accessLevel;
        private Location loc;

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
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
            }
        }
        
        public User()
        {
            payment = 0;
            accessLevel = 0;
        }
    }
}

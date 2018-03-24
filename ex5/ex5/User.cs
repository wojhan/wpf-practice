using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ex5
{
    class User
    {
        private string firstname, lastname, email;

        public string FirstName
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
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
                if(!(new EmailAddressAttribute().IsValid(value)))
                {
                    throw new FormatException("It's not valid email address");
                }
                email = value;
            }
        }

        public override string ToString()
        {
            return firstname + " " + lastname + ", " + email;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4_EgnaProjekt.UserMenu
{
    public class LoginUsers
    {
        private string _username;
        private string _password;
        private int _role;
        private string _firstName;
        private string _lastName;

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        public int Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    _firstName = "Agent";
                }
                else
                {
                    _firstName = value;
                }
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    _lastName = "Smith";
                }
                else
                {
                    _lastName = value;
                }
            }
        }
        public LoginUsers(string username, string password, string firstName, string lastName, int role)
        {
            Username = username;
            Password = password;
            Role = role;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}

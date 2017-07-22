using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStepPhone.Menu.LoginPage
{
    public class User
    {
        public string login { get; set; }
        public string password { get; set; }

        public User()
        { }

        public User(string _login, string _password)
        {
            login = _login;
            password = _password;
        }

        public bool isLogin()
        {
            return login != "" ? true : false;
        }
    }
}

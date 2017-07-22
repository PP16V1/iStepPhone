using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace iStepPhone.Menu.LoginPage
{
    public class LoginPg
    {
        List<User> db = new List<User>();

        public void Registration()
        {
            db.Add(new User(EmailInput(), PasswordInput()));
            Console.WriteLine("Registration completed successfully");
        }

        public void LogIn()
        {
        }

        public void LogOut()
        {
        }

        private string EmailInput()
        {
            string patternMail = @"[A-Za-z0-9]{3,10}@[a-zA-Z0-9]{2,5}\.[a-zA-Z0-9]{2,3}";
            Regex regExEmail = new Regex(patternMail);
            string email = "";
            bool validEmail = false;
            do
            {
                Console.Clear();
                if (!validEmail)
                {
                    Console.WriteLine("Enter your email");
                    email = Console.ReadLine();
                    if (regExEmail.IsMatch(email))
                        validEmail = true;
                    else
                    {
                        Console.WriteLine("Invalid input");
                        Console.Read();
                    }
                }
            } while (!validEmail);
            return email;
        }

        private string PasswordInput()
        {
            string patternPass = @"[a-zA-Z0-9]+$";
            Regex regExPass = new Regex(patternPass);
            string password = "";
            bool validPass = false;

            do
            {
                Console.Clear();
                if (!validPass)
                {
                    Console.WriteLine("Enter your password");
                    password = Console.ReadLine();
                    if (regExPass.IsMatch(password))
                        validPass = true;
                    else
                    {
                        Console.WriteLine("Password must contain Latin letters and numbers");
                        Console.Read();
                    }
                }
            } while (!validPass);
            return password;
        }

    }
}

using System;
using System.IO;

namespace TopList
{
    public class TopList
    {
        private const string PasswordFileName = "Password.TopList";

        public TopList()
        {
            Console.WriteLine("Topplistan");

            CreateNewPasswordFileIfNotExist();

            Login();
        }


        private bool ValidateUserLogin(string login)
        {
            if (login == "user")
                return true;
            else
                return false;
        }

        private bool ValidateAdministratorLogin(string login)
        {
            if (login == "admin")
                return true;
            else
                return false;
        }

        private string RequestLoginFromUser()
        {
            Console.WriteLine("Please Login");
            return Console.ReadLine(); 
        }

        private void CreateNewPasswordFileIfNotExist()
        {
            if (CheckIfPasswordFileExist() == false)
            {
                string[] lines = { "Administrator;admin", "Administrator;admin2" };
                System.IO.File.WriteAllLines(PasswordFileName, lines);
            }
        }

        private bool CheckIfPasswordFileExist()
        {
            if (File.Exists(PasswordFileName))
                return true;
            else
                return false;
        }
        private void Login()
        {
            while (true)
            {
                string login = RequestLoginFromUser();

                if (login.Length <= 0)
                    Console.WriteLine("Password must be minimun 1 character");

                else
                {
                    if (ValidateAdministratorLogin(login))
                    {
                        Console.WriteLine("Welcome Administrator");
                        break;
                    }
                    else
                    {
                        if (ValidateUserLogin(login))
                        {
                            Console.WriteLine("Welcome User");
                            break;
                        }
                        else
                            Console.WriteLine("Wrong Password");
                    }
                }
            }
        }
    }
}

using System;
using System.IO;

namespace TopList
{
    public class TopList
    {

        public TopList()
        {
            TopListAdministrator Admin;
            TopListUser User;

            Console.WriteLine("Topplistan");

            CreateNewPasswordFileIfNotExist();

            string UserName = Login();

            if (UserName == "Administrator")
            {
                Admin = new TopListAdministrator();
            }
            else 
            {
                User = new TopListUser(UserName);
            }
        }


        private bool ValidateUserLogin(string login)
        {
            string line;

            System.IO.StreamReader file =
                new System.IO.StreamReader(Common.PasswordFileName);
            while ((line = file.ReadLine()) != null)
            {
                string[] RowStrings = line.Split(';');

                if (RowStrings[0] == "User")
                {
                    if (RowStrings[1] == login)
                    {
                        file.Close();
                        return true;
                    }

                }
            }

            file.Close();
            return false;
        }

        private bool ValidateAdministratorLogin(string login)
        {

            string line;

            System.IO.StreamReader file =
                new System.IO.StreamReader(Common.PasswordFileName);
            while ((line = file.ReadLine()) != null)
            {
                string[] RowStrings = line.Split(';');

                if (RowStrings[0] == "Administrator")
                {
                    if (RowStrings[1] == login)
                    {
                        file.Close();
                        return true;
                    }
                        
                }
            }

            file.Close();
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
                string[] lines = { "Administrator;admin;DarkRed" };
                System.IO.File.WriteAllLines(Common.PasswordFileName, lines);
            }
        }

        private bool CheckIfPasswordFileExist()
        {
            if (File.Exists(Common.PasswordFileName))
                return true;
            else
                return false;
        }
        private string Login()
        {
            string Username = "";
            while (true)
            {
                string login = RequestLoginFromUser();

                if (login.Length <= 0)
                    Console.WriteLine("Password must be minimun 1 character");

                else
                {
                    if (ValidateAdministratorLogin(login))
                    {
                        Username = "Administrator";
                        break;
                    }
                    else
                    {
                        if (ValidateUserLogin(login))
                        {
                            Username = login;
                            break;
                        }
                        else
                            Console.WriteLine("Wrong Password");
                    }
                }
            }
            return Username;
        }
    }
}

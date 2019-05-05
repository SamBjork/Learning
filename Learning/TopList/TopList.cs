using System;
using System.IO;

namespace TopList
{
    public class TopList
    {

        public TopList()
        {

            Console.WriteLine("Topplistan");

            CreateNewPasswordFileIfNotExist();

            string UserName = Login();

            if (UserName == "Administrator")
            {
                TopListAdministrator Admin = new TopListAdministrator();
            }
            else 
            {
                TopListUser User = new TopListUser(UserName);
            }
        }


        private bool ValidateUserLogin(string login)
        {
            string line;

            StreamReader file = new StreamReader(Common.PasswordFileName);

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

            StreamReader file = new StreamReader(Common.PasswordFileName);

            line = file.ReadLine();

            while ( line != null)
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

                line = file.ReadLine();
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
                string[] lines = { "Administrator;admin;DarkRed","User;Yngwe;Purple" };
                File.WriteAllLines(Common.PasswordFileName, lines);
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
                string InputFromUser = RequestLoginFromUser();

                if (InputFromUser.Length <= 0)
                    Console.WriteLine("Password must be minimun 1 character");

                else
                {
                    if (ValidateAdministratorLogin(InputFromUser))
                    {
                        Username = "Administrator";
                        break;
                    }
                    else
                    {
                        if (ValidateUserLogin(InputFromUser))
                        {
                            Username = InputFromUser;
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

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
            if (CheckIfPasswordFileExist() == false)
            {
                //if password file not exist
                CreateNewPasswordFile();

            }
        }
       
        private void CreateNewPasswordFile()
        {
            string[] lines = {"Administrator;admin", "Administrator;admin2"};
            System.IO.File.WriteAllLines(PasswordFileName, lines);


        }

        private bool CheckIfPasswordFileExist()
        {
            if (File.Exists(PasswordFileName))
                return true;
            else
                return false;
        }
    }
}

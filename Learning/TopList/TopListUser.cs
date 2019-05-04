using System;
namespace TopList
{
    public class TopListUser
    {
        private const string WelcomeText = "Welcome ";
        public TopListUser(string UserName)
        {
            string UserColor = GetUserColor(UserName);
            Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), UserColor, true);
            Console.Clear();
            string WelcomeAndUserName = WelcomeText + UserName;
            int CurPos = (Console.WindowWidth / 2) - ((WelcomeAndUserName).Length / 2);

            Console.SetCursorPosition(CurPos, 0);
            Console.WriteLine(WelcomeAndUserName);
        }

        private string GetUserColor(string UserName)
        {
            string line;

            System.IO.StreamReader file =
                new System.IO.StreamReader(Common.PasswordFileName);
            while ((line = file.ReadLine()) != null)
            {
                string[] RowStrings = line.Split(';');

                if (RowStrings[0] == "User")
                {
                    if (RowStrings[1] == UserName)
                    {
                        
                        file.Close();
                        return RowStrings[2];
                    }

                }
            }

            file.Close();
            return "Magenta";
        }







    }
}

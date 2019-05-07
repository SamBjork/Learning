using System;
namespace TopList
{
    public class TopListAdministrator
    {
        private const string WelcomeText = "Welcome Administrator";
        public TopListAdministrator()
        {
            string UserColor = GetUserColor("Administrator");
            Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), UserColor, true);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Red;
            int CurPos = (Console.WindowWidth / 2) - (WelcomeText.Length / 2);

            Console.SetCursorPosition(CurPos, 5);
            Console.WriteLine(WelcomeText);
        }
        
        private string GetUserColor(string UserName)
        {
            string line;

            System.IO.StreamReader file =
                new System.IO.StreamReader(Common.PasswordFileName);
            while ((line = file.ReadLine()) != null)
            {
                string[] RowStrings = line.Split(';');

                if (RowStrings[0] == UserName)
                {
                   
                        file.Close();
                        return RowStrings[2];

                }
            }

            file.Close();
            return "Magenta";
        }


    }
}


using System.Text;
using static UserLogin.Enums;

namespace UserLogin
{
    class Program
    {
        public static void PrintError(string errorMsg)
        {
            Console.WriteLine("!!! " + errorMsg + " !!!");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter username:");
            String username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            String password = Console.ReadLine();
            LoginValidation loginValidation = new(username, password, PrintError);
            User user = new User();
            bool isValid = loginValidation.ValidateUserInput(user);
            if (isValid)
            {
                DisplayUserInfo(user);
                StartProgramMenu(user);
            }
            else
            {
                Console.WriteLine("User is not valid");
            }
        }

        private static void DisplayUserInfo(User user)
        {
            Console.WriteLine(user.Username);
            Console.WriteLine(user.FakNum);
            switch ((UserRoles)user.Role)
            {
                case UserRoles.ANONYMOUS:
                    Console.WriteLine("Logged as ANONYMOUS");
                    break;
                case UserRoles.ADMIN:
                    Console.WriteLine("Logged as ADMIN");
                    break;
                case UserRoles.INSPECTOR:
                    Console.WriteLine("Logged as INSPECTOR");
                    break;
                case UserRoles.PROFESSOR:
                    Console.WriteLine("Logged as PROFESSOR");
                    break;
                case UserRoles.STUDENT:
                    Console.WriteLine("Logged as STUDENT");
                    break;

            }
        }

        private static void StartProgramMenu(User user)
        {
            try
            {
                String username = user.Username;
                if (UserRoles.ADMIN.Equals((UserRoles)user.Role))
                {
                    PrintAdminMenu(username);
                }
                else
                {
                    PrintMenu(username);
                }
            }
            catch (Exception e) when (e is FormatException or ArgumentNullException)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void PrintMenu(String username)
        {
            Console.WriteLine("0 Exit");
            Console.WriteLine("1 Change the role of the user");
            Console.WriteLine("2 Change the active time of the user");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    AskForRoleChange();
                    break;
                case 2:
                    AskForActiveTimeChange();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        static void PrintAdminMenu(String username)
        {
            Console.WriteLine("0 Exit");
            Console.WriteLine("1 Change the role of the user");
            Console.WriteLine("2 Change the active time of the user");
            Console.WriteLine("3 Show User list");
            Console.WriteLine("4 Show log file");
            Console.WriteLine("5 Show current session log");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    AskForRoleChange();
                    break;
                case 2:
                    AskForActiveTimeChange();
                    break;
                case 3:
                    break;
                case 4:
                    ShowAcitvityLogFile();
                    break;
                case 5:
                    StringBuilder sb = new StringBuilder();
                    IEnumerable<string> currentSesstionLog = Logger.GetCurrentSessionActivities("");
                    foreach (string s in currentSesstionLog)
                    {
                        sb.Append(s);
                    }
                    Console.WriteLine(currentSesstionLog);
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }


        private static void AskForRoleChange()
        {
            Console.WriteLine("Enter user:");
            String userToChangeRole = Console.ReadLine();
            Console.WriteLine("Enter new role:");
            String newRole = Console.ReadLine();
            UserData.ChangeUserRole(userToChangeRole, newRole);
        }

        private static void AskForActiveTimeChange()
        {
            Console.WriteLine("Enter user:");
            String usernameToChangeActiveTime = Console.ReadLine();
            Console.WriteLine("Enter new active time:");
            DateTime userDateTime;
            if (DateTime.TryParse(Console.ReadLine(), out userDateTime))
            {
                UserData.SetUserActiveTimeTo(usernameToChangeActiveTime, userDateTime);
            }
            else
            {
                Console.WriteLine("Invalid date");
            }
        }
        private static void ShowAcitvityLogFile()
        {
            try
            {
                IEnumerable<string> logFile = Logger.GetLogActivity();
                Console.Write(logFile);
            }
            catch (FileNotFoundException e)
            {
                Console.Write("Unable to get log activity: " + e.Message);
            }
        }
}   }
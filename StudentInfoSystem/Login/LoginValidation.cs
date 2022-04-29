using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentInfoSystem.Enums;

namespace StudentInfoSystem
{
    internal class LoginValidation
    {
        public static UserRoles currentUserRole;
        public static string currentUserName;
        public String username;
        private String password;
        private String errorMessage;
        private ActionOnError _errorfunc;

        public delegate void ActionOnError(string errorMsg);

        public LoginValidation(String username, String password, ActionOnError actionOnError)
        {
            this._errorfunc = actionOnError;
            this.username = username;
            this.password = password;
        }


        public bool ValidateUserInput(User user)
        {
            Boolean emptyUserName;
            emptyUserName = username.Equals(String.Empty);

            if (emptyUserName == true)
            {
                currentUserRole = UserRoles.ANONYMOUS;
                errorMessage = "Username not set";
                _errorfunc(errorMessage);
                return false;
            }

            Boolean emptyPassword;
            emptyPassword = password.Equals(String.Empty);

            if (emptyUserName == true)
            {
                currentUserRole = UserRoles.ANONYMOUS;
                errorMessage = "Username not set";
                _errorfunc(errorMessage);
                return false;
            }
            if (username.Length < 5)
            {
                currentUserRole = UserRoles.ANONYMOUS;
                errorMessage = "Username is too short";
                _errorfunc(errorMessage);
                return false;
            }
            if (password.Length < 5)
            {
                currentUserRole = UserRoles.ANONYMOUS;
                errorMessage = "Password is too short";
                _errorfunc(errorMessage);
                return false;
            }
            User userFromUserData = UserData.IsUserPassCorrect(username, password);
            if (user == null)
            {
                currentUserRole = UserRoles.ANONYMOUS;
                errorMessage = "User not found";
                _errorfunc(errorMessage);
                return false;
            }
            user.Username = userFromUserData.Username;
            user.Password = userFromUserData.Password;
            user.FakNum = userFromUserData.FakNum;
            user.Role = userFromUserData.Role;
            currentUserName = user.Username;
            currentUserRole = (UserRoles)user.Role;
            Logger.LogActivity("Successful Login");
            return true;
        }

    }
}

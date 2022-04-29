using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentInfoSystem.Enums;

namespace StudentInfoSystem
{
    public static class UserData
    {
        public static List<User> _testUsers;

        public static List<User> TestUsers
        {

            get
            {
                ResetUserData(); 
                return _testUsers;

            }

            set
            {
                _testUsers = value;
            }
            
        }
        static private void ResetUserData()
        {
            if (_testUsers == null)
            {
                TestUsers = new List<User>();
                User admin = new User();
                admin.Username = "admin";
                admin.Password = "password";
                admin.FakNum = "00000";
                admin.Role = (int)Enums.UserRoles.ADMIN;
                admin.CreatedDate = DateTime.Now;
                admin.ActiveTime = DateTime.MaxValue;
                User student_1 = new User();
                student_1.Username = "student1";
                student_1.Password = "password1";
                student_1.FakNum = "00001";
                student_1.Role = (int)Enums.UserRoles.STUDENT;
                student_1.CreatedDate = DateTime.Now;
                student_1.ActiveTime = DateTime.MaxValue;
                User student_2 = new User();
                student_2.Username = "student2";
                student_2.Password = "password2";
                student_2.FakNum = "00002";
                student_2.Role = (int)Enums.UserRoles.STUDENT;
                student_2.CreatedDate = DateTime.Now;
                student_2.ActiveTime = DateTime.MaxValue;
                TestUsers.Add(student_2);
                TestUsers.Add(student_1);
                TestUsers.Add(admin);

            }
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            return (from user in TestUsers where user.Username == username && user.Password == password select user).First();
        }

        public static void SetUserActiveTimeTo(string username, DateTime newActiveTime)
        {
            foreach (User user in TestUsers)
            {
                if (user.Username == username)
                {
                    user.ActiveTime = newActiveTime;
                    Logger.LogActivity("Changed the active time of " + username);
                }
            }
        }
        public static void ChangeUserRole(string username, string role)
        {
            foreach (User user in TestUsers)
            {
                if (user.Username == username)
                {
                    user.Role = (int)Enums.UserRoles.Parse(typeof(UserRoles), role);
                    Logger.LogActivity("Changed the role of " + username + " to " + role);
                }
            }
        }
    }
}

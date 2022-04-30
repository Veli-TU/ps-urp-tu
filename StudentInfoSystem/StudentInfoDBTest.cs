using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public  class StudentInfoDBTest
    {
        public static  bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();
            return countStudents == 0;
        }

        public static bool TestUsersIfEmpty()
        {
            UserContext context = new UserContext();
            IEnumerable<User> queryUsers = context.Users;
            int countUsers = queryUsers.Count();
            return countUsers == 0;
        }

        public static void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student st in StudentData.TestStudents)
            {
                context.Students.Add(st);
            }
             context.SaveChanges();
        }

        public static void CopyTestUsers()
        {
            UserContext context = new UserContext();
            foreach (User us in UserData.TestUsers)
            {
                context.Users.Add(us);
            }
            context.SaveChanges();
        }
    }
}

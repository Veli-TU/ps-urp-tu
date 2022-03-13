using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    public class StudentValidation
    {
        public static Student GetStudentDataByUser(User user)
        {
            if (user.FakNum == null)
            {
                Console.WriteLine("User faculty number is empty");
                return null;
            } 
            foreach (Student student in StudentData.TestStudents)
            {
                if (student.facultyNumber == user.FakNum)
                {
                    return student;
                }
            }
            Console.WriteLine("User not found");
            return null;
        }
    }
}

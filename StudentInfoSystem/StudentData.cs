using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    internal class StudentData
    {
        public static readonly List<Student> TestStudents = GetTestStudents();
        static public List<Student> GetTestStudents()
        {
            List<Student> students = new List<Student>();
            Student student = new Student();
            student.facultyNumber = "00000";
            student.name = "TestStudent";
            student.surname = "TestSurname";
            student.lastName = "TestLastName";
            student.faculty = "TestFaculty";
            student.specalty = "TestSpecalty";
            student.degree = "TestDegree";
            student.status = "TestStatus" ;
            student.kurs = "TestKurs";
            student.potok = "TestPotok" ;
            students.Add(student) ;
            return students;
        }
    }
}

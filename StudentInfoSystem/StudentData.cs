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
            student.status = 3;
            student.kurs = "TestKurs";
            student.potok = "TestPotok" ;
            student.student_group = "Test group";
            students.Add(student) ;
            return students;
        }
        
        private static Student IsThereStudent(string facNum)
        {
            StudentInfoContext context = new StudentInfoContext();
            Student result =
            (from st in context.Students
             where st.facultyNumber == facNum
             select st).First();
            return result;
        }
    }
}

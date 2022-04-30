using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {
        public StartupWindow()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            string username = usernameBox.Text.ToString();
            string password = passwordBox.Password.ToString();
            if(username != null && password != null)
            {
                try
                {
                    tryToLogin(username, password);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Unable to login");
                }
            }
            
        }

        private void tryToLogin(string username, string password)
        {
            for (int i = 0; i < UserData.TestUsers.Count; i++)
            {
                User user = UserData.IsUserPassCorrect(username, password);
                Student student = StudentValidation.GetStudentDataByUser(user);
                // if (username.Equals(user.Username) && password.Equals(user.Password))
                if (student != null)
                {
                    MainWindow studentInfoWindow = new StudentInfoSystem.MainWindow(student);
                    Logger.LogActivity("Student "  + student.name  + " logged in");
                    studentInfoWindow.Show();
                    return;
                }
            }
        }

        private void TestDB(object sender, RoutedEventArgs e)
        {

            bool studentsEmpty = StudentInfoDBTest.TestStudentsIfEmpty();
            if (studentsEmpty)
                StudentInfoDBTest.CopyTestStudents();
            bool usersEmpty = StudentInfoDBTest.TestUsersIfEmpty();
            if (usersEmpty)
                StudentInfoDBTest.CopyTestUsers();
        }


    }
}


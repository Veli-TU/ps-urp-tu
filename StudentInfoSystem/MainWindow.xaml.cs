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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> StudStatusChoices { get; set; }
        public Student student;

        public MainWindow(Student student)
        {
            this.student = student;
            InitializeComponent();
            FillStudStatusChoices();
            Student_Info_In_Forms(student);
            DataContext = this;
        }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery =
                @"SELECT StatusDescr FROM StudentInfoDatabase.dbo.StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();

                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    Console.WriteLine(s);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }


        }

        private void Student_Info_In_Forms(Student student)
        {
            TextBoxName.Text = student.name;
            TextBoxSurname.Text = student.surname;
            TextBoxLastName.Text = student.lastName;
            TextBoxFaculty.Text = student.faculty;
            TextBoxSpecalty.Text = student.specalty;
            TextBoxOKS.Text = student.degree;
            TextBoxFakNumber.Text = student.facultyNumber;
            TextBoxKurs.Text = student.kurs;
            TextBoxPotok.Text = student.potok;
            TextBoxGroup.Text = student.student_group;
        }

        private void Disable_All_Forms(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    TextBox textBox = (TextBox)item;
                    textBox.IsEnabled = false;
                }
            }
        }

        private void Enable_All_Forms()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    TextBox textBox = (TextBox)item;
                    textBox.IsEnabled = true;
                }
            }
        }

        private void Reset_All_Forms()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    TextBox textBox = (TextBox)item;
                    textBox.Text = null;
                }
            }
        }

    }
}

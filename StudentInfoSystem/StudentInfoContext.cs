using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    internal class StudentInfoContext : DbContext
    {

        public DbSet<Student> Students { get; set; }

        public DbSet<User> Users { get; set; }

        public StudentInfoContext() : base(Properties.Settings.Default.DbConnect)
        {
     



        }
    }
}

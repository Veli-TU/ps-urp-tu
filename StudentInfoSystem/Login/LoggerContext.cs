using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem.Login
{
    internal class LoggerContext : DbContext
    {
        public DbSet<Activity> activity  { get; set; }

        public LoggerContext() : base(Properties.Settings.Default.DbConnect)
        {




        }
    }
}

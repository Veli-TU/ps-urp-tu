using System;

namespace StudentInfoSystem
{
    public class User
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String FakNum { get; set; }
        public Int32 Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ActiveTime { get; set; }
    }
}

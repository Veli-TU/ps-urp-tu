using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    internal static class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();
        static public void LogActivity(string activity)
        {

            string activityLine = DateTime.Now + ";"    
                + LoginValidation.currentUserName + ";"
                + LoginValidation.currentUserRole + ";"
                + activity;
            currentSessionActivities.Add(activityLine);
            File.AppendAllText("TestFile.txt", activityLine);
        }

        public static IEnumerable<string> GetLogActivity()
        {
            try
            {
                StreamReader sr = new StreamReader("TestFile.txt");

                List<string> fileContents = new List<string>();
                while (!sr.EndOfStream)
                {
                    fileContents.Add(sr.ReadLine());
                }
                return fileContents;
            }
            catch(FileNotFoundException e)
            {
                File.Create("TestFile.txt");
                throw e;
            }
        }

        public static IEnumerable<string> GetCurrentSessionActivities(string filter )
        {
            List<string> filteredActivities = (from activity in currentSessionActivities
             where activity.Contains(filter)
             select activity).ToList();
            return currentSessionActivities;
        }

    }
}

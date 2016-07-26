using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Drive_Test_Formatter
{
    class Logfile
    {
        public string TextFile { get; set; }
        public string Now {
            get{
                return "[" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:s") + "] ";
            }
        }

        public Logfile(string directory, string logFileName)
        {
            Directory.CreateDirectory(directory);
            if (!File.Exists(directory + @"\" + logFileName))
            {
                File.WriteAllText(directory + @"\" + logFileName, "Started logging at " + Now + Environment.NewLine + Environment.NewLine);
            }
            TextFile = directory + @"\" + logFileName;
        }

        public void logException(Exception e)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(TextFile, true))
            {
                file.WriteLine(Now + e + Environment.NewLine + Environment.NewLine);
            }
        }

        public void logMessage(string message)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(TextFile, true))
            {
                file.WriteLine(Now + message + Environment.NewLine + Environment.NewLine);
            }
        }
    }
}

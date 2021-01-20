using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WorkMonitorigSystem
{
    public class Logger
    {
        public static string currentDate;
        public static string path;
        public static void Log(string path, string message)
        {
            TextWriter tw = new StreamWriter(path, true);
            tw.WriteLine(message);
            tw.Close();
        }
    }
}

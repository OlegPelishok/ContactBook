using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contacktbook
{
    public class LoggerClass
    {
        public void writeLog(string exceptionText)
        {
            using (StreamWriter writer = File.AppendText("Log.txt"))
            {
                writer.WriteLine((DateTime.Now.ToString()) + exceptionText);
            }	
        }
    }
}

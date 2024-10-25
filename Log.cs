using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal static class Log
    {
        public static void writeLog(string message)
        {

            string path_log = AppDomain.CurrentDomain.BaseDirectory + "../../../logs/";
            path_log += DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            path_log += "_log.txt";

            try
            {
                string fileDir = Path.GetDirectoryName(path_log);
                if (!Directory.Exists(fileDir))
                {
                    Directory.CreateDirectory(fileDir);
                }

                using (StreamWriter writer = new StreamWriter(path_log))
                {
                    writer.WriteLine(message);
                    Console.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment1
{
    internal class Mainpoint
    {
        static void Main()
        {
            // start program
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            DirWalker fw = new DirWalker();
            SimpleCSVParser cp = new SimpleCSVParser();

            // Extract all files
            string path_dir = AppDomain.CurrentDomain.BaseDirectory + "../../../Sample data";
            fw.walk(path_dir);

            // Extract all rows across all files
            foreach (string csvf in fw.fileList)
            {
                cp.csvParse(csvf);
            }

            // Write all rows in one file
            string write_path_dir = AppDomain.CurrentDomain.BaseDirectory + "../../../Output/result.csv";
            cp.csvWrite(write_path_dir);

            // Write log
            stopwatch.Stop();
            string message = "Total execution time is ";
            message += stopwatch.Elapsed.ToString(@"mm\:ss");
            message += "  --Total number of valid rows is ";
            message += cp.valid_row_count.ToString();
            message += "  --Total number of skipped rows is ";
            message += cp.skip_row_count.ToString();
            Log.writeLog(message);
        }
    }
}

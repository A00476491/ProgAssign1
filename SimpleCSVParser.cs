using System;
using System.IO;
using System.Reflection.Metadata;
using Microsoft.VisualBasic.FileIO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment1
{
    public class SimpleCSVParser
    {
        public void csvParse(string fileName)
        {
            try
            {
                using (TextFieldParser parser = new TextFieldParser(fileName))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    if (has_header)
                    {
                        parser.ReadFields();
                    }
                    else {
                        has_header = true;
                    }

                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        if (Array.Exists(fields, string.IsNullOrEmpty))
                        {
                            skip_row_count += 1;
                        }
                        else {
                            content.Add(fields.ToList());
                            valid_row_count += 1;
                        }
                    }
                }
            }
            catch (IOException ioe)
            {
                Log.writeLog(ioe.StackTrace);
            }
        }

        public void csvWrite(string filePath)
        {
            string fileDir = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(fileDir))
            {
                Directory.CreateDirectory(fileDir);
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (List<string> c in content)
                {
                    string row = string.Join(",", c);
                    writer.WriteLine(row);
                }
            }

        }

        public List<List<string>> content = new List<List<string>>();
        private bool has_header = false;
        public long valid_row_count = -1;
        public long skip_row_count = 0;
    }
}

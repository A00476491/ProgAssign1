using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment1
{
  

    public class DirWalker
    {

        public void walk(String path)
        {
            string[] list = Directory.GetDirectories(path);

            if (list == null) return;

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath);
                }

                fileList.AddRange(Directory.GetFiles(dirpath));
            }
        }

        public List<string> fileList = new List<string> { };

    }
}

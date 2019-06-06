using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace FindAndReplace
{
    public class FileAccess
    {
        public string ReadFile(string filePath)
        {
            string result;
            using (StreamReader sr = new StreamReader(filePath))
            {
                result = sr.ReadToEnd();
            }
            return result;
        }

        public void WriteFile(string filePath, string contents)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(contents);
            }
        }
    }
}

using System;
using System.IO;
namespace file_io_part1_exercises_pair
{
    /*
     * Get the file, read the line
     * 
     * */
    class Program
    {
        static void Main(string[] args)
        {
            int wordCount = 0;
            int sentenceCount = 0;
            string path1 = @"C:\Users\georgd\georgdeckner-c-sharp-material\module-1\17_FileIO_Reading_in\student-exercise\alices_adventures_in_wonderland.txt";
            string line;
            using (StreamReader sr = new StreamReader(path1))
            {
                line = sr.ReadToEnd();
            }
            foreach(char x in line)
            {
                if(x.Equals(' '))
                {
                    wordCount++;
                }
            }
            foreach(char x in line)
            {
                int index = 0;
                if(x.Equals('!') || x.Equals('?') || x.Equals('.'))
                {
                    if(!line[index + 1].Equals('"') && !line[index + 1].Equals('!') && !line[index + 1].Equals('?'))
                    {
                        sentenceCount++;
                    }
                }
                index++;
            }
            Console.WriteLine(wordCount);
            Console.WriteLine(sentenceCount);
        }
    }
}

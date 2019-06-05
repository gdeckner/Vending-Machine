using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FindAndReplace
{
    public class CommandLineInterface
    {
      
        FileAccess file = new FileAccess();

        public void Run()
        {
            bool isValidPath = false;
            string directory = "";
            string fileName = "";
            string fullPath = "";

            while (isValidPath == false)
            {
                Console.WriteLine("Please enter the fully qualified directory for the file you would like to read: ");
                directory = Console.ReadLine();

                Console.WriteLine("Please enter the name of the text file you would like to read: ");
                fileName = Console.ReadLine();

                fullPath = Path.Combine(directory, fileName);

                isValidPath = File.Exists(fullPath);

                if (isValidPath == false)
                {
                    Console.WriteLine("Path was invalid, please try again.");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Please enter the word you would like to search for: ");
            string searchWord = Console.ReadLine();

            Console.WriteLine("Please enter the word you would like to replace it with: ");
            string replaceWord = Console.ReadLine();

            string originalContents = file.ReadFile(fullPath);
            string newContents = originalContents.Replace(searchWord, replaceWord);

            isValidPath = false; 

            while (isValidPath == false)
            {
                Console.WriteLine("Please enter the fully qualified directory for the file you would like to write to: ");
                directory = Console.ReadLine();

                Console.WriteLine("Please enter the name of the text file you would like to create or overwrite: ");
                fileName = Console.ReadLine();

                fullPath = Path.Combine(directory, fileName);

                isValidPath = Directory.Exists(directory);

                if (isValidPath == false)
                {
                    Console.WriteLine("Directory does not exist, please try again.");
                    Console.WriteLine();
                }
            }

            file.WriteFile(fullPath, newContents);
        }







        
    }
}

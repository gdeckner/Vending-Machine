using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Exercises
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            int sum = 0;
            string[] numberSplit = Regex.Split(numbers, @"\D+");
            for (int i = 0; i < numberSplit.Length; i++)
            {
                if (numberSplit[i] == "")
                {

                }
                else
                {
                    sum += Convert.ToInt32(numberSplit[i]);
                    Console.WriteLine(numberSplit[i]);
                }

            }


            return sum;
        }
    }
}








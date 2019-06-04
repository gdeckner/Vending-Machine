using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises
{
    public class WordToNumber
    {
        public int WordToNumberConverter(string num)
        {
            Dictionary<string, int> myDictionary = new Dictionary<string, int> {
                { "one",1},{"two",2},{"three",3},{"four",4},{"five",5},{"six",6},{"seven",7},{"eight",8},{"nine",9},{"ten",10},{"eleven",11}
            ,{"twelve",12},{"thirteen",13},{"fourteen",14},{"fifteen",15},{"sixteen",16},{"seventeen",17},{"eightteen",18},{"nineteen",19},{"twenty",20},
            {"thirty",30 },{"forty",40},{"fifty",50},{"sixty",60},{"seventy",70},{"eighty",80},{"ninety",90},{"hundred",100},{"thousand",1000}

            };
            bool hasNextA = false;
            bool hasThirdThouse = false;
            string[] numArray = num.Split(" ");
            string[] dashSplit;
            int sum = 0;
            int a = 0;
            int b = 0;
            int c = 0;

            for (int i = 0; i < numArray.Length; i++)
            {
                if(numArray.Length >= 3)
                {
                    numArray[2].Contains("thousand");
                    hasThirdThouse = true;
                    sum += myDictionary[numArray[i]] * 100000;
                    i = i + 2;
                }
                try
                {
                    hasNextA = (numArray[i + 2].Contains("and") ? true : false);
                }
                catch
                {
                    hasNextA = false;
                }

                if (hasNextA)
                {
                    if (numArray[i].Contains('-'))
                    {
                        dashSplit = numArray[i].Split('-');
                        a = myDictionary[dashSplit[0]];
                        b = myDictionary[dashSplit[1]];
                        c += a + b;
                        sum += c;

                    }
                    else
                    {
                        sum += myDictionary[numArray[i]] * myDictionary[numArray[i + 1]];
                    }

                }
                if (!hasNextA)
                {
                   
                    if (i == numArray.Length - 1)
                    {
                        if (numArray[i].Contains('-'))
                        {
                            dashSplit = numArray[i].Split('-');
                            a = myDictionary[dashSplit[0]];
                            b = myDictionary[dashSplit[1]];
                            c += a + b;
                            sum += c;

                        }
                        else
                        {
                            sum += myDictionary[numArray[i]];
                        }
                       
                    }
                    else if (numArray.Length == 2)
                    {
                        
                        sum += myDictionary[numArray[i]] * myDictionary[numArray[i + 1]];
                        break;
                    }
                    
                }
            }
            return sum;
        }
    }
}








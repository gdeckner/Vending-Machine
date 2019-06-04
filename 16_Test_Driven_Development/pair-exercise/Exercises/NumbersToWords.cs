using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises
{
    public class NumbersToWords
    {
        Dictionary<int, string> wordsStuff = new Dictionary<int, string>
        {
            {0,"zero" },{1,"one"},{2,"two"},{3,"three"},{4,"four"},{5,"five"},{6,"six"},{7,"seven"},{8,"eight"},{9,"nine"},{10,"ten"},{11,"eleven"}
            ,{12,"twelve"},{13,"thirteeen"},{14,"fourteen"},{15,"fifteen"},{16,"sixteen"},{17,"seventeen"},{18,"eightteen"},{19,"nineteen"},{20,"twenty"},
            {30,"thirty" },{40,"forty"},{50,"fifty"},{60,"sixty"},{70,"seventy"},{80,"eighty"},{90,"ninety"},{100,"hundred"},{1000,"thousand"}
        };

        string result = "";
        int y = 0;


        public string NumbersToWordsOneDigit(int num)
        {
            result = wordsStuff[num];
            return result;
        }

        public string NumbersToWordsTwoDigit(int num)
        {
            if (wordsStuff.ContainsKey(num))
            {
                result = wordsStuff[num];
            }
            else
            {
                y = Convert.ToInt32(num.ToString().Substring(0, 1));
                y *= 10;
                result = wordsStuff[y] + "-" + NumbersToWordsOneDigit(Convert.ToInt32(num.ToString().Substring(1, 1)));
            }

            return result;
        }

        public string NumbersToWordsThreeDigit(int num)
        {
            result = wordsStuff[Convert.ToInt32(num.ToString().Substring(0, 1))] + " hundred";

            if (num.ToString().Substring(1, 2) != "00")
            {
                result += " and " + NumbersToWordsTwoDigit(Convert.ToInt32(num.ToString().Substring(1, 2)));
            }

            return result;
        }

        public string NumbersToWordsFourDigit(int num)
        {
            result = wordsStuff[Convert.ToInt32(num.ToString().Substring(0, 1))] + " thousand";
            
            if (num.ToString().Substring(1, 3) != "000")
            {
                if (Convert.ToInt32(num.ToString().Substring(1, 3))/100 != 0)
                {
                    result += " and " + NumbersToWordsThreeDigit(Convert.ToInt32(num.ToString().Substring(1, 3)));
                }
                else if (Convert.ToInt32(num.ToString().Substring(1, 3))/10 != 0)
                {
                    result += " and " + NumbersToWordsTwoDigit(Convert.ToInt32(num.ToString().Substring(2, 2)));
                }
                else
                {
                    result += " and " + NumbersToWordsOneDigit(Convert.ToInt32(num.ToString().Substring(3, 1)));
                }
                
            }

            return result;
        }

        public string NumbersToWordsFiveDigits(int num)
        {
            result = NumbersToWordsTwoDigit(Convert.ToInt32(num.ToString().Substring(0, 2))) + " thousand";

            if (num.ToString().Substring(1, 4) != "0000")
            {
                
                if (Convert.ToInt32(num.ToString().Substring(1, 4)) / 1000 != 0)
                {
                    result += " and " + NumbersToWordsFourDigit(Convert.ToInt32(num.ToString().Substring(1, 4)));
                }
                else if (Convert.ToInt32(num.ToString().Substring(1, 4)) / 100 != 0)
                {
                    result += " and " + NumbersToWordsThreeDigit(Convert.ToInt32(num.ToString().Substring(2, 3)));
                }
                else if (Convert.ToInt32(num.ToString().Substring(1, 4)) / 10 != 0)
                {
                    result += " and " + NumbersToWordsTwoDigit(Convert.ToInt32(num.ToString().Substring(3, 2)));
                }
                else
                {
                    result += " and " + NumbersToWordsOneDigit(Convert.ToInt32(num.ToString().Substring(4, 1)));
                }
            }

            return result;
        }

        //public string NumbersToWordsConvert(int num)
        //{
        //    //Dictionary<int, string> wordsStuff = new Dictionary<int, string>
        //{
        //    {0,"zero" },{1,"one"},{2,"two"},{3,"three"},{4,"four"},{5,"five"},{6,"six"},{7,"seven"},{8,"eight"},{9,"nine"},{10,"ten"},{11,"eleven"}
        //    ,{12,"twelve"},{13,"thirteeen"},{14,"fourteen"},{15,"fifteen"},{16,"sixteen"},{17,"seventeen"},{18,"eightteen"},{19,"nineteen"},{20,"twenty"},
        //    {30,"thirty" },{40,"forty"},{50,"fifty"},{60,"sixty"},{70,"seventy"},{80,"eighty"},{90,"ninety"},{100,"hundred"},{1000,"thousand"}
        //};
        //string fullNumber = num.ToString();
        //string result = "";
        //int y = 0;

        //int caseVar = num.ToString().Length;

        //switch (caseVar)
        //{

        //    case 1:
        //        result = wordsStuff[num];
        //        break;
        //    case 2:
        //        if (num <= 19 && num >= 10)
        //        {
        //            result = wordsStuff[num];

        //        }
        //        else
        //        {
        //            y = Convert.ToInt32(num.ToString().Substring(0, 1));
        //            y *= 10;
        //            if (y == num)
        //            {
        //                result = wordsStuff[y];
        //            }
        //            else
        //            {
        //                result = wordsStuff[y] + "-" + wordsStuff[Convert.ToInt32(num.ToString().Substring(1))];
        //            }
        //        }
        //        break;
        //    case 3:
        //        y = Convert.ToInt32(num.ToString().Substring(0, 1));
        //        y *= 100;
        //        if (y == num)
        //        {
        //            result = wordsStuff[Convert.ToInt32(num.ToString().Substring(0, 1))] + " hundred";
        //        }
        //        else
        //        {
        //            if (fullNumber.Substring(1, 1) == "0")
        //            {
        //               result = wordsStuff[Convert.ToInt32(num.ToString().Substring(0, 1))] + " hundred and ";
        //               result += wordsStuff[Convert.ToInt32(num.ToString().Substring(2, 1))];
        //            }
        //            else
        //            {
        //                y = Convert.ToInt32(num.ToString().Substring(1, 1));
        //                y *= 10;
        //                if (y == num)
        //                {
        //                    result = wordsStuff[Convert.ToInt32(num.ToString().Substring(0, 1))] + " hundred and ";
        //                    result = wordsStuff[y];
        //                }
        //                else
        //                {
        //                    y = Convert.ToInt32(num.ToString().Substring(1));
        //                    result = wordsStuff[Convert.ToInt32(num.ToString().Substring(0, 1))] + " hundred and ";
        //                    if (y <= 19 && y >= 10)
        //                    {
        //                        result += wordsStuff[y];

        //                    }
        //                    else
        //                    {
        //                        y = Convert.ToInt32(num.ToString().Substring(1, 1));
        //                        y *= 10;
        //                        if (y == num)
        //                        {
        //                            result = wordsStuff[y];
        //                        }
        //                        else
        //                        {

        //                            result += wordsStuff[y] + "-" + wordsStuff[Convert.ToInt32(num.ToString().Substring(2))];
        //                        }
        //                    }

        //                }


        //            }
        //        }

        //        break;
        //    case 4:
        //        y = Convert.ToInt32(num.ToString().Substring(0, 1));
        //        y *= 1000;

        //        if (y == num)
        //        {
        //            result = wordsStuff[Convert.ToInt32(num.ToString().Substring(0, 1))] + " thousand";
        //        }
        //        else
        //        {

        //        }
        //        break;
        //    case 5:
        //        break;
        //    case 6:
        //        break;

        //}

        //return result;
    }
    
}

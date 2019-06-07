using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {
        private VendingMachine vendingMachine = new VendingMachine();
        private bool SelectedMenuTwo = false;
        private bool Done = false;


        public void RunInterface()
        {
            

            while (!Done)
            {
                MenuOne();

                if (SelectedMenuTwo)
                {
                    MenuTwo();
                }

            }

        }


        public void MenuOne()
        {
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) End");


            string answer = Console.ReadLine();

            switch (answer)
            {
                case "1":
                    Console.WriteLine(vendingMachine.Display());
                    Console.WriteLine();
                    break;
                case "2":
                    SelectedMenuTwo = true;
                    break;
                case "3":
                    Done = true;
                    break;
                default:
                    Console.WriteLine("Invalid input, please try again.");
                    break;
            }



        }

        public void MenuTwo()
        {
            bool menuTwoDone = false;

            while (!menuTwoDone)
            {
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.WriteLine($"Current Money Provided: $ {vendingMachine.Balance}");

                Console.WriteLine();
                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        bool donePaying = false;
                        bool isValid = false;

                        Console.WriteLine("INSERT BILLS NOW ($1, $2, $5, $10, etc.");
                        answer = Console.ReadLine();

                        while (!donePaying)
                        {
                            isValid = vendingMachine.FeedMoney(answer);
                            if (isValid)
                            {
                                Console.WriteLine("Are you done? Press (Y) to continue, (N) to exit");

                                if (answer == "y")
                                {
                                    donePaying = true;
                                }
                                else if (answer == "n")
                                {
                                    donePaying = false;
                                }
                                else
                                {
                                    donePaying = false;
                                }
                            }

                        }
                        break;
                    case "2":
                        //GEORG
                        break;
                    case "3":
                        menuTwoDone = true;
                        Console.WriteLine(vendingMachine.ReturnChange());
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }


        }
    }


}

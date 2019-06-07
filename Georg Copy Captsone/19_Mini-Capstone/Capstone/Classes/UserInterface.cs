using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {
        private VendingMachine vendingMachine = new VendingMachine(@"C:\Users\georgd\georgdeckner-c-sharp-material\team5-c-sharp-week4-pair-exercises\19_Mini-Capstone\etc\vendingmachine.csv");
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
            Console.WriteLine();

            string answer = Console.ReadLine();
            Console.WriteLine();

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
                case "9":
                    vendingMachine.PrintSalesReport();
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
                Console.WriteLine();

                switch (answer)
                {
                    case "1":
                        bool donePaying = false;
                        bool isValid = false;

                        while (!donePaying)
                        {

                            Console.WriteLine("INSERT BILLS NOW ($1, $2, $5, $10, etc.)");
                            Console.WriteLine();

                            answer = Console.ReadLine();
                            Console.WriteLine();

                            isValid = vendingMachine.FeedMoney(answer);
                            if (isValid)
                            {
                                Console.Write("Would you like to add more funds? (Y/N) ");
                                Console.WriteLine();

                                answer = Console.ReadLine().ToLower();

                                if (answer == "y")
                                {
                                    donePaying = false;
                                }
                                else if (answer == "n")
                                {
                                    donePaying = true;
                                }
                                else
                                {
                                    donePaying = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid entry, please try again.");
                                Console.WriteLine();
                            }

                        }
                        break;
                    case "2":
                        Console.WriteLine(vendingMachine.Display());

                        Console.WriteLine("Please enter the slot identifier: ");
                        answer = Console.ReadLine();
                        Console.WriteLine();

                        Console.WriteLine(vendingMachine.Purchase(answer));

                        if(!vendingMachine.Purchase(answer).Contains('!'))
                        {
                            Console.WriteLine(vendingMachine.ConsumptionMessage(answer));
                        }
                        
                        Console.WriteLine();
                        break;

                    case "3":
                        menuTwoDone = true;
                        Console.WriteLine(vendingMachine.ReturnChange(vendingMachine.Balance));
                        vendingMachine.PrintAudit();
                        SelectedMenuTwo = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }


        }
    }


}

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        private List<VendingMachineItem> items = new List<VendingMachineItem>();

        //private string filePath = @"C:\VendingMachine";
        private string filePath = @"C:\Users\georgd\georgdeckner-c-sharp-material\team5-c-sharp-week4-pair-exercises\19_Mini-Capstone\etc\vendingmachine.csv";

        public double Balance { get; set; }
        public bool CanPurchase = false;
        public string CurrentDateTime { get; set; }
        public List<string[]> AuditData;

        public VendingMachine()
        {
            generateInfo(filePath);
        }



        public bool FeedMoney(string input)
        {
            CurrentDateTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            bool valid = false;
            string[] feedAudit = new string[] { CurrentDateTime, "FEED MONEY", input, Balance.ToString() };
            AuditData.Add(feedAudit);
            return valid;
        }

        public string ReturnChange()
        {
            CurrentDateTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string change = "";
            /* loop and create change */
            //TORY
            string[] feedAudit = new string[] { CurrentDateTime, "FEED MONEY", Balance.ToString(), "0" };
            AuditData.Add(feedAudit);
            Balance = 0;
            return change;
        }
        public bool Purchase(string input)
        {
            CurrentDateTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string oldBalance = Balance.ToString();
            string nameAndSlot = "";
            /* if item exists canPurchase = true
             *  else returns false
             *  
             * if true
             *  balance -= price
             *  item quanity - 1
             *  return true */
            //GEORG
            string[] feedAudit = new string[] { CurrentDateTime, nameAndSlot, oldBalance, Balance.ToString() };
            AuditData.Add(feedAudit);

            return CanPurchase;
        }



        public void generateInfo(string filePath)
        {
            string line;
            using (StreamReader sr = new StreamReader(filePath))
            {
                while(!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    string[] item = line.Split('|');
                    int index = items.Count;

                    items.Add(new VendingMachineItem());
                    items[index].Slot = item[0];
                    items[index].Name = item[1];
                    items[index].Price = item[2];
                    items[index].Quantity = 5;
                } 





            }

        }

        public string Display()
        {
            string displayString = " k";
            //GEORG

            return displayString;
        }

        public void PrintAudit()
        {
            //TORY
        }


    }
}

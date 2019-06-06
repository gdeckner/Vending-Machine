using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        private List<VendingMachineItem> items = new List<VendingMachineItem>();
        
        private string filePath = @"C:\VendingMachine";

        public double Balance { get; set; }
        public bool CanPurchase = false;
        public string DateTime { get; set; }
        public List<string[]> AuditData;

        public double FeedMoney(string input)
        {
            
            string[] feedAudit = new string[] { DateTime, "FEED MONEY", input, Balance.ToString() };
            AuditData.Add(feedAudit);
            return Balance;
        }

        public string ReturnChange(double input)
        {
            string change = "";
            /* loop and create change */

            string[] feedAudit = new string[] { DateTime, "FEED MONEY", Balance.ToString(), "0" };
            AuditData.Add(feedAudit);
            Balance = 0;
            return change;
        }
        public bool Purchase(string input)
        {
            string oldBalance = Balance.ToString();
            string nameAndSlot = "";
            /* if item exists canPurchase = true
             *  else returns false
             *  
             * if true
             *  balance -= price
             *  item quanity - 1
             *  return true */

            string[] feedAudit = new string[] { DateTime, nameAndSlot, oldBalance, Balance.ToString()};
            AuditData.Add(feedAudit);

            return CanPurchase;


        }

        public string[] AddItems(string line)
        {
            string[] item = line.Split('|');
            int index = items.Count;

            items[index].Slot = item[0];
            items[index].Name = item[1];
            items[index].Price = item[2];
            items[index].Quantity = 5;

            return item;
        }

        public string Display()
        {
            string displayLine = "";

            foreach (VendingMachineItem item in items)
            {
               
                displayLine += $"item[0] item[1] item[2] item[3]" + "\n";
                
            }

            return displayLine;

        }




    }
}

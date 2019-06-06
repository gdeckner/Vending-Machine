using System;
using System.IO;
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
        public string CurrentDateTime { get; set; }
        public List<string[]> AuditData;

        public VendingMachine()
        {
            generateInfo(filePath);
        }



        public bool FeedMoney(string input)
        {
            int feedInput = Convert.ToInt32(input);
            CurrentDateTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            bool valid = false;
            if(feedInput == 1 || feedInput == 2 || feedInput == 5 || feedInput == 10)
            {
                valid = true;
                Balance += Convert.ToDouble(input);
                string[] feedAudit = new string[] { CurrentDateTime, "FEED MONEY", input, Balance.ToString() };
                AuditData.Add(feedAudit);
            }
           
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
        { //Need to give specific error message based on why it was unable to purchase, 
          // either via setting string property or something else
            CurrentDateTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string oldBalance = Balance.ToString();
            string nameAndSlot = "";
            double getPrice = 0;
         foreach (VendingMachineItem x in items)
            {
                if (x.Slot.ToLower().Equals(input))
                {

                    getPrice = Convert.ToDouble(x.Slot);
                    if (Balance > getPrice && x.Quantity > 0)
                    {
                        CanPurchase = true;
                    }
                    else
                    {
                        CanPurchase = false;
                        return false;
                        
                    }
                }
                if (CanPurchase)
                {
                    Balance -= getPrice;
                    x.Quantity -= 1;
                    return true;
                }
            }


            string[] feedAudit = new string[] { CurrentDateTime, nameAndSlot, oldBalance, Balance.ToString() };
            AuditData.Add(feedAudit);

            return CanPurchase;
        }

        public void generateInfo(string filePath)
        {
            string line;
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
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
            string displayString = "";
           foreach(VendingMachineItem x in items)
            {
                if(x.Quantity == 0)
                {
                    displayString = String.Format("{0,-20} {1,-10} {2,-10} {3,-10}", x.Slot,x.Name,x.Price,"Sold Out!");
                }
                else
                {
                    displayString = String.Format("{0,-20} {1,-10} {2,-10} {3,-10}", x.Slot, x.Name, x.Price,x.Quantity);
                }
            }

            return displayString;
        }

        public void PrintAudit()
        {
            //TORY
        }
    }
}












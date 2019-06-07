using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        private List<VendingMachineItem> items = new List<VendingMachineItem>();
        protected string filePath = @"C:\Users\georgd\georgdeckner-c-sharp-material\team5-c-sharp-week4-pair-exercises\19_Mini-Capstone\etc\vendingmachine.csv";
        public double Balance { get; set; }
        public bool CanPurchase = false;
        public string CurrentDateTime { get; set; }
        public List<string[]> AuditData = new List<string[]>();

        public VendingMachine()
        {
            generateInfo(filePath);
        }



        public bool FeedMoney(string input)
        {
            double feedInput = 0;

            try
            {
                feedInput = Convert.ToDouble(input);
            }
            catch
            {
                
                return false;
            }
            
            CurrentDateTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            bool valid = false;
            if(feedInput == 1 || feedInput == 2 || feedInput == 5 || feedInput == 10)
            {
                valid = true;
                Balance += Convert.ToDouble(input);
                string[] feedAudit = new string[] { CurrentDateTime, "FEED MONEY", feedInput.ToString(), Balance.ToString() };
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
            string displayString = String.Format("   {0,-5}  {1,-20} {2,-10} {3,-10}", "Slot","Item Name","Price","Amount");
            displayString += "\n" + "\n";
           for(int i = 0; i < items.Count;i++)
            {
                if(items[i].Quantity == 0)
                {
                    displayString += String.Format("    {0,-5} {1,-20} {2,-10} {3,-10}", items[i].Slot, items[i].Name, items[i].Price,"Sold Out!");
                    displayString += "\n";
                }
                else
                {
                    displayString += String.Format("    {0,-5} {1,-20} {2,-10} {3,-10}", items[i].Slot, items[i].Name, items[i].Price, items[i].Quantity);
                    displayString += "\n";
                }
            }
            Console.WriteLine(displayString);
            return displayString;
        }

        public void PrintAudit()
        {
            //TORY
        }
    }
}












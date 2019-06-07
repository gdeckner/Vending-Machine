using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        private List<VendingMachineItem> items = new List<VendingMachineItem>();
        private string FilePath = @"C:\VendingMachine";
        public double Balance { get; set; }
        public string CurrentDateTime
        {
            get
            {
                return DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            }
        }
        private List<string[]> AuditData = new List<string[]>();


        public VendingMachine()
        {
            generateInfo(FilePath);
        }
        public VendingMachine(string filePath)
        {
            FilePath = filePath;
            generateInfo(FilePath);
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
            bool valid = false;
            if (feedInput == 1 || feedInput == 2 || feedInput == 5 || feedInput == 10)
            {
                valid = true;
                Balance += Convert.ToDouble(input);
                string[] feedAudit = new string[] { CurrentDateTime, "FEED MONEY", feedInput.ToString(), Balance.ToString() };
                AuditData.Add(feedAudit);
            }

            return valid;
        }

        public string ReturnChange(double balance)
        {
           
            string change = "";

            int returnAmount = (int)(balance * 100);

            int quarters = returnAmount / 25;
            returnAmount = returnAmount % 25;

            int dimes = returnAmount / 10;
            returnAmount = returnAmount % 10;

            int nickels = returnAmount / 5;
            returnAmount = returnAmount % 5;

            int pennies = returnAmount / 1;

            change = $"Your change is {quarters} quarters, {dimes} dimes, {nickels} nickels, and {pennies} pennies, and total of {balance}";

            string[] feedAudit = new string[] { CurrentDateTime, "GIVE CHANGE", Balance.ToString(), "0" };
            AuditData.Add(feedAudit);
            Balance = 0;

            return change;
        }

        public string Purchase(string input)
        { 
            string oldBalance = Balance.ToString();
            string nameAndSlot = "";
            double getPrice = 0;
            bool canPurchase = false;
            foreach (VendingMachineItem x in items)
            {
                if (x.Slot.ToLower().Equals(input))
                {

                    getPrice = Convert.ToDouble(x.Price);
                    if (Balance > getPrice && x.Quantity > 0)
                    {
                        canPurchase = true;
                        nameAndSlot = x.Name + " " + x.Slot;
                    }
                    else if(getPrice > Balance)
                    {
                        canPurchase = false;
                        return "Not enough funds!";
                    }
                    else if(x.Quantity == 0)
                    {
                        canPurchase = false;
                        return "Item is sold out!";
                    }
                    if (canPurchase)
                    {
                        Balance -= getPrice;
                        x.Quantity -= 1;
                        string[] feedAudit = new string[] { CurrentDateTime, nameAndSlot, oldBalance, Balance.ToString() };
                        AuditData.Add(feedAudit);

                        return "You have succesfully purchased " + nameAndSlot;
                    }

                }

            }

            return "Item not found!";  
        }

        public string ConsumptionMessage(string input)
        {
            string message = "";

            if ((input.ToLower().Contains("a") == true))
            {
                message = "Crunch Crunch, Yum!";
            }

            if ((input.ToLower().Contains("b") == true))
            {
                message = "Munch Munch, Yum!";
            }

            if ((input.ToLower().Contains("c") == true))
            {
                message = "Glug Glug, Yum!";
            }

            if ((input.ToLower().Contains("d") == true))
            {
                message = "Chew Chew, Yum!";
            }

            return message;
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
            string displayString = String.Format("   {0,-5}  {1,-20} {2,-10} {3,-10}", "Slot", "Item Name", "Price", "Amount");
            displayString += "\n";
            for (int i = 0; i < 45; i++)
            {
                displayString += "=";
            }
            displayString += "\n";
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Quantity == 0)
                {
                    displayString += String.Format("    {0,-5} {1,-20} {2,-10}    {3,-10}", items[i].Slot, items[i].Name, items[i].Price, "Sold Out!");
                    displayString += "\n";
                }
                else
                {
                    displayString += String.Format("    {0,-5} {1,-20} {2,-10} {3,-10}", items[i].Slot, items[i].Name, items[i].Price, items[i].Quantity);
                    displayString += "\n";
                }
            }
            return displayString;
        }

        public void PrintAudit()
        {
            using (StreamWriter sr = new StreamWriter(@"C:\VendingMachine\Log.txt", true))
            {
                foreach (string[] entry in AuditData)
                {
                    string line = String.Format("{0,-20}     {1,-25}     {2,-5} {3,-5}", entry[0], entry[1], entry[2], entry[3]);
                    sr.WriteLine(line);
                }
            }
        }

        public void PrintSalesReport()
        {
            double totalSales = 0;
            string salesDateTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm tt");
            salesDateTime = salesDateTime.Replace('/', '_').Replace(':', '-').Replace(' ', '_');
            
            string saleReportName = @"C:\VendingMachine\" + salesDateTime+ "_SalesReport.txt";
            using (StreamWriter sw = new StreamWriter(saleReportName))
            {
                for (int i = 0; i < items.Count; i++)
                {
                    sw.WriteLine(items[i].Name + "|" + Math.Abs(items[i].Quantity - 5) + "\n");
                    totalSales += (Convert.ToDouble(items[i].Price) * (Math.Abs(items[i].Quantity - 5)));
                    totalSales = Math.Round(totalSales, 2);
                }
                sw.WriteLine("** TOTAL SALES **  " + totalSales);
            }
        }
    }
}















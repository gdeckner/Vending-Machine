using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTest
    {
        VendingMachine newObject;

        [TestInitialize]
        public void Initialize()
        {
            newObject = new VendingMachine();
           
        }
        [TestMethod]
        public void FeedMoneyTest()
        {
            Assert.AreEqual(false, newObject.FeedMoney("f"), "Expected false, returned true");
            Assert.AreEqual(false, newObject.FeedMoney("54"), "Expected false, returned true");
            Assert.AreEqual(false, newObject.FeedMoney("2.45"), "Expected false, returned true");
            Assert.AreEqual(true, newObject.FeedMoney("1.00"), "Expected true, returned false");
            Assert.AreEqual(true, newObject.FeedMoney("1"), "Expected true, returned false");
            Assert.AreEqual(true, newObject.FeedMoney("2.00"), "Expected true, returned false");
            Assert.AreEqual(true, newObject.FeedMoney("2"), "Expected true, returned false");
            newObject.FeedMoney("5");
            Assert.AreEqual(5, newObject.Balance, "Expected 5 but returned " + newObject.Balance);
            newObject.FeedMoney("10");
            Assert.AreEqual(10, newObject.Balance, "Expected 10 but returned " + newObject.Balance);
            
        }

    }
}

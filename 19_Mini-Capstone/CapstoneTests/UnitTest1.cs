using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class UnitTest1
    {
         UserInterface newObject;

        [TestInitialize]
        public void Initialize()
        {
            newObject = new UserInterface();  
        }
        
        [TestMethod]
        public void TestMethod1()
        {

        }
        [TestMethod]
        public void FeedMoneyTest()
        {

        }
    }
}

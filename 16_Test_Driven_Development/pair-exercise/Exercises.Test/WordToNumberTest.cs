using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercises;

namespace Exercises.Test
{
    [TestClass]
    public class WordToNumberTest
    {
        WordToNumber newObject;

        [TestInitialize]
        public void Initialize()
        {
            newObject = new WordToNumber();
        }

        [TestMethod]
        public void WordToNumberConverterOneDigit()
        {
            Assert.AreEqual(9, newObject.WordToNumberConverter("nine"));
        }

        [TestMethod]
        public void WordToNumberConverterTwoDigit()
        {
            Assert.AreEqual(19, newObject.WordToNumberConverter("nineteen"));
            Assert.AreEqual(12, newObject.WordToNumberConverter("twelve"));
        }

        [TestMethod]
        public void WordToNumberConverterThreeDigit()
        {
            Assert.AreEqual(314, newObject.WordToNumberConverter("three hundred and fourteen"));
            Assert.AreEqual(500, newObject.WordToNumberConverter("five hundred"));
        }

        [TestMethod]
        public void WordToNumberConverterFourDigit()
        {
            Assert.AreEqual(3140, newObject.WordToNumberConverter("three thousand and one hundred and forty"));
            Assert.AreEqual(5009, newObject.WordToNumberConverter("five thousand and nine"));
            Assert.AreEqual(5023, newObject.WordToNumberConverter("five thousand and twenty-three"));
        }

        [TestMethod]
        public void WordToNumberConverterSixDigit()
        {
            Assert.AreEqual(100000, newObject.WordToNumberConverter("one hundred thousand"));
            Assert.AreEqual(638002, newObject.WordToNumberConverter("six hundred and thirty-eight thousand and two"));
            Assert.AreEqual(114734, newObject.WordToNumberConverter("one hundred and fourteen thousand and seven hundred and thirty-four"));
        }



    }
}

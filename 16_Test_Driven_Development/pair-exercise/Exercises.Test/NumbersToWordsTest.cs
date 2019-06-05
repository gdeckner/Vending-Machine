using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercises;

namespace Exercises.Test
{
    [TestClass]
    public class NumbersToWordsTest
    {
        NumbersToWords newObject;

        [TestInitialize]
        public void Initialize()
        {
            newObject = new NumbersToWords();
        }

        [TestMethod]
        public void NumbersToWordsOneDigit()
        {
            Assert.AreEqual("nine", newObject.NumbersToWordsOneDigit(9));
            Assert.AreEqual("seven", newObject.NumbersToWordsOneDigit(7));
            Assert.AreEqual("zero", newObject.NumbersToWordsOneDigit(0));
        }

        [TestMethod]
        public void NumbersToWordsTwoDigit()
        {
            Assert.AreEqual("ten", newObject.NumbersToWordsTwoDigit(10));
            Assert.AreEqual("eleven", newObject.NumbersToWordsTwoDigit(11));
            Assert.AreEqual("twelve", newObject.NumbersToWordsTwoDigit(12));
            Assert.AreEqual("fourteen", newObject.NumbersToWordsTwoDigit(14));
            Assert.AreEqual("thirty-seven", newObject.NumbersToWordsTwoDigit(37));
            Assert.AreEqual("sixty-four", newObject.NumbersToWordsTwoDigit(64));
        }

        [TestMethod]
        public void NumbersToWordsThreeDigit()
        {
            Assert.AreEqual("one hundred and nine", newObject.NumbersToWordsThreeDigit(109));
            Assert.AreEqual("five hundred", newObject.NumbersToWordsThreeDigit(500));
            Assert.AreEqual("three hundred and fourteen", newObject.NumbersToWordsThreeDigit(314));
            Assert.AreEqual("six hundred and twenty-four", newObject.NumbersToWordsThreeDigit(624));

        }

        [TestMethod]
        public void NumbersToWordsFourDigit()
        {
            Assert.AreEqual("one thousand and one hundred and seventeen", newObject.NumbersToWordsFourDigit(1117));
            Assert.AreEqual("five thousand", newObject.NumbersToWordsFourDigit(5000));
            Assert.AreEqual("three thousand and seventy-four", newObject.NumbersToWordsFourDigit(3074));
            Assert.AreEqual("one thousand and nine", newObject.NumbersToWordsFourDigit(1009));
        }

        [TestMethod]
        public void NumbersToWordsFiveDigit()
        {
            Assert.AreEqual("forty thousand", newObject.NumbersToWordsFiveDigits(40000));
            Assert.AreEqual("eighty-seven thousand and six hundred and seventeen", newObject.NumbersToWordsFiveDigits(87617));
            Assert.AreEqual("thirty-two thousand and five hundred", newObject.NumbersToWordsFiveDigits(32500));
            Assert.AreEqual("fourteen thousand and eleven", newObject.NumbersToWordsFiveDigits(14011));
        }

        //[TestMethod]
        //public void NumbersToWordsSixDigit()
        //{
        //    Assert.AreEqual("eight hundred thousand", newObject.NumbersToWordsConvert(800000));
        //    Assert.AreEqual("six hundred and seventy thousand", newObject.NumbersToWordsConvert(670000));
        //    Assert.AreEqual("three hundred and forty-one thousand and fifteen", newObject.NumbersToWordsConvert(341015));
        //    Assert.AreEqual("one hundred and seventeen thousand and seven hundred and twenty-nine", newObject.NumbersToWordsConvert(117729));
        //}


    }
}

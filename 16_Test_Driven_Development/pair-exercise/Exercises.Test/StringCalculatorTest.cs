using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Test
{
    [TestClass]
    public class UnitTest1
    {
        StringCalculator newObject;

        [TestInitialize]
        public void Initialize()
        {
            newObject = new StringCalculator();
        }
            

        [TestMethod]
        public void StringCalculatorEmptyString()
        {
            Assert.AreEqual(0, newObject.Add(""));
        }

        [TestMethod]
        public void StringCalculatorOneDigit()
        {
            Assert.AreEqual(9, newObject.Add("9"));
        }

        [TestMethod]
        public void StringCalculatorTwoDigits()
        {
            Assert.AreEqual(12, newObject.Add("9,3"));
        }

        [TestMethod]
        public void StringCalculatorUnlimited()
        {
            Assert.AreEqual(18, newObject.Add("9,3,6"));
            Assert.AreEqual(24, newObject.Add("5,6,8,3,2"));
            Assert.AreEqual(36, newObject.Add("1,2,3,4,5,6,7,8"));
        }

        [TestMethod]
        public void StringCalculatorNewLine()
        {
            Assert.AreEqual(18, newObject.Add("9\n3,6"));
            
        }

        [TestMethod]
        public void StringCalculatorOtherDelimiter()
        {
            Assert.AreEqual(18, newObject.Add("//9!3!6"));
        }
    }
}

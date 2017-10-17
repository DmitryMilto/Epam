using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2__NUnit_
{
    [TestFixture]
    class NUnitTest
    {
        [Test]
        public void AddTestPl()
        {
            double result = Calculator.Plus(4, 9);
            Assert.AreEqual(13, result);
        }
        [Test]
        public void AddTestPl2()
        {
            double result = Calculator.Plus(9, 9);
            Assert.AreEqual(13, result);
        }
        [Test]
        public void AddTestPl3()
        {
            double result = Calculator.Plus(1, 9);
            Assert.AreEqual(10, result);
        }
        [Test]
        public void AddTestPl4()
        {
            double result = Calculator.Plus(4, 4);
            Assert.AreEqual(6, result);
        }
        [Test]
        public void AddTestPl5()
        {
            double result = Calculator.Plus(0, 9);
            Assert.AreEqual(9, result);
        }
        [Test]
        public void AddTestMin()
        {
            double result = Calculator.Minus(9, 4);
            Assert.AreEqual(5, result);
        }
        [Test]
        public void AddTestMin2()
        {
            double result = Calculator.Minus(9, 9);
            Assert.AreEqual(0, result);
        }
        [Test]
        public void AddTestMin3()
        {
            double result = Calculator.Minus(9, 1);
            Assert.AreEqual(7, result);
        }
        [Test]
        public void AddTestMin4()
        {
            double result = Calculator.Minus(9, 18);
            Assert.AreEqual(5, result);
        }
        [Test]
        public void AddTestMin5()
        {
            double result = Calculator.Minus(9, 5);
            Assert.AreEqual(4, result);
        }
        [Test]
        public void AddTestDel()
        {
            double result = Calculator.Square(8);
            Assert.AreEqual(2, result);
        }
        [Test]
        public void AddTestDel2()
        {
            double result = Calculator.Square(25);
            Assert.AreEqual(5, result);
        }
        [Test]
        public void AddTestDel3()
        {
            double result = Calculator.Square(121);
            Assert.AreEqual(11, result);
        }
        [Test]
        public void AddTestDel4()
        {
            double result = Calculator.Square(69);
            Assert.AreEqual(1, result);
        }
        [Test]
        public void AddTestDel5()
        {
            double result = Calculator.Square(16);
            Assert.AreEqual(4, result);
        }
        [Test]
        public void AddTestYmn()
        {
            double result = Calculator.Power(4, 2);
            Assert.AreEqual(16, result);
        }
        [Test]
        public void AddTestYmn2()
        {
            double result = Calculator.Power(2, 2);
            Assert.AreEqual(4, result);
        }
        [Test]
        public void AddTestYmn3()
        {
            double result = Calculator.Power(4, 4);
            Assert.AreEqual(16, result);
        }
        [Test]
        public void AddTestYmn4()
        {
            double result = Calculator.Power(4, 1);
            Assert.AreEqual(4, result);
        }
        [Test]
        public void AddTestYmn5()
        {
            double result = Calculator.Power(2, 2);
            Assert.AreEqual(4, result);
        }
    }
}

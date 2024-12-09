using NUnit.Framework;
using NaturalNumsLib;
namespace NaturalNumsTest
{
    public class EvenTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TwoIsEvenNumber()
        {
            bool result = NaturalNumbers.IsEven(2);
            Assert.IsTrue(result);
        }
        [Test]
        public void FiveIsOdd()//нечетное
        {
            bool result = NaturalNumbers.IsEven(5);
            Assert.IsFalse(result);
        }
        [Test]
        public void Value2020IsEven()
        {
            bool result = NaturalNumbers.IsEven(2020);
            Assert.IsTrue(result);
        }
    }
    public class GcdTests
    {
        [Test]
        public void SameValues()
        {
            int expected = 888;
            int actual = NaturalNumbers.GCD(888, 888);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void NumberAndOneGivesOne()
        {
            int expected = 1;
            int actual = NaturalNumbers.GCD(23, 1);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void FirstValueIsGcd()
        {
            int expected = 15;
            int actual = NaturalNumbers.GCD(15, 45);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void SecondValueIsGcd()
        {
            int expected = 15;
            int actual = NaturalNumbers.GCD(45, 15);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TwoValues()
        {
            int expected = 8;
            int actual = NaturalNumbers.GCD(32, 24);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void RaznieChisla()
        {
            int expected = 1;
            int actual = NaturalNumbers.GCD(49, 50);
            Assert.AreEqual(expected, actual);
        }

    }
    public class IsPrimeTests
    {
        [Test]
        public void IsPrimeValue7()
        {
            bool result = NaturalNumbers.IsPrime(7);
            Assert.IsTrue(result);
        }
        [Test]
        public void IsNotPrimeValue()
        {
            bool result = NaturalNumbers.IsPrime(42);
            Assert.IsFalse(result);
        }
        [Test]
        public void TwoValue()
        {
            bool result = NaturalNumbers.IsPrime(2);
            Assert.IsTrue(result);
        }
        [Test]
        public void OneValue()
        {
            bool result = NaturalNumbers.IsPrime(1);
            Assert.IsFalse(result);
        } 
    }
}
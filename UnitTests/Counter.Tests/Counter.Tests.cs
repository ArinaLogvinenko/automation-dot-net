using NUnit.Framework;
using Counter;
using System;

namespace Counter.Tests
{
    [TestFixture]  
    public class Tests
    {
        [Test]
        public void GetMaxCountOfUniqueSequenceOfLetters_StringIsNull_ThrowsArgumentNullException()
        {
            //ARRANGE
            var counter = new CounterService();

            //ACT + ASSERT
            Assert.Throws<ArgumentNullException>(() => counter.GetMaxCountOfUniqueSequenceOfLetters(null));
        }

        [Test]
        public void GetMaxCountOfUniqueSequenceOfLetters_StringIsEmpty_ThrowsArgumentNullException()
        {
            //ARRANGE
            var counter = new CounterService();

            //ACT + ASSERT
            Assert.Throws<ArgumentNullException>(() => counter.GetMaxCountOfUniqueSequenceOfLetters(string.Empty));
        }

        [Test]
        public void GetMaxCountOfUniqueSequenceOfLetters_StringIsWhitespace_ThrowsArgumentNullException()
        {
            //ARRANGE
            var counter = new CounterService();

            //ACT + ASSERT
            Assert.Throws<ArgumentNullException>(() => counter.GetMaxCountOfUniqueSequenceOfLetters("      "));
        }

        [Test]
        [TestCase("sadwedsaaaa", 8)]
        [TestCase("aaaaaaaaaaaaa", 1)]
        [TestCase("s", 1)]
        [TestCase("aaaaserf", 5)]
        public void GetMaxCountOfUniqueSequenceOfLetters_CorrectResults_Tests(string value, int expected)
        {
            //ARRANGE
            var counter = new CounterService();

            //ACT
            var actual = counter.GetMaxCountOfUniqueSequenceOfLetters(value);

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetMaxCountOfTheSameLatinLetters_StringIsNull_ThrowsArgumentNullException()
        {
            //ARRANGE
            var counter = new CounterService();

            //ACT + ASSERT
            Assert.Throws<ArgumentNullException>(() => counter.GetMaxCountOfTheSameLatinLetters(null));
        }

        [Test]
        public void GetMaxCountOfTheSameLatinLetters_StringIsEmpty_ThrowsArgumentNullException()
        {
            //ARRANGE
            var counter = new CounterService();

            //ACT + ASSERT
            Assert.Throws<ArgumentNullException>(() => counter.GetMaxCountOfTheSameLatinLetters(string.Empty));
        }

        [Test]
        public void GetMaxCountOfTheSameLatinLetters_StringIsWhitespace_ThrowsArgumentNullException()
        {
            //ARRANGE
            var counter = new CounterService();

            //ACT + ASSERT
            Assert.Throws<ArgumentNullException>(() => counter.GetMaxCountOfTheSameLatinLetters("      "));
        }

        [Test]
        [TestCase("aaaas//***rtg", 4)]
        [TestCase("str&///////////gaaaaa", 5)]
        [TestCase("a", 1)]
        [TestCase("qwefffffqwe", 5)]
        [TestCase("aaa//233333333qwesdaaaaaaads", 7)]
        public void GetMaxCountOfTheSameLatinLetters_CorrectResults_Tests(string value, int expected)
        {
            //ARRANGE
            var counter = new CounterService();

            //ACT
            var actual = counter.GetMaxCountOfTheSameLatinLetters(value);

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetMaxCountOfTheSameDigits_StringIsNull_ThrowsArgumentNullException()
        {
            //ARRANGE
            var counter = new CounterService();

            //ACT + ASSERT
            Assert.Throws<ArgumentNullException>(() => counter.GetMaxCountOfTheSameDigits(null));
        }

        [Test]
        public void GetMaxCountOfTheSameDigits_StringIsEmpty_ThrowsArgumentNullException()
        {
            //ARRANGE
            var counter = new CounterService();

            //ACT + ASSERT
            Assert.Throws<ArgumentNullException>(() => counter.GetMaxCountOfTheSameDigits(string.Empty));
        }

        [Test]
        public void GetMaxCountOfTheSameDigits_StringIsWhitespace_ThrowsArgumentNullException()
        {
            //ARRANGE
            var counter = new CounterService();

            //ACT + ASSERT
            Assert.Throws<ArgumentNullException>(() => counter.GetMaxCountOfTheSameDigits("      "));
        }

        [Test]
        [TestCase("1234////*5555", 4)]
        [TestCase("55555/////&&&&&&", 5)]
        [TestCase("5", 1)]
        [TestCase("**/sad0000000/..,,", 7)]
        [TestCase("aaa//233333333qwesdaaaaaaads", 8)]
        public void GetMaxCountOfTheSameDigits_CorrectResults_Tests(string value, int expected)
        {
            //ARRANGE
            var counter = new CounterService();

            //ACT
            var actual = counter.GetMaxCountOfTheSameDigits(value);

            //ASSERT
            Assert.AreEqual(expected, actual);
        }
    }
}
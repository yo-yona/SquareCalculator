using NUnit.Framework;
using SquareCalculatorLib;
using System;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsThisRight_3and4and5_ReturnTrue()
        {
            int a = 3, b = 4, c = 5;
            var act = SquareCalculatorLib.Calculator.IsThisRight(a, b, c);
            Assert.That(act, Is.True);
        }
        [Test]
        public void IsThisRight_3and4and6_ReturnFalse()
        {
            int a = 3, b = 4, c = 6;
            var act = SquareCalculatorLib.Calculator.IsThisRight(a, b, c);
            Assert.That(act, Is.False);
        }
        [Test]
        public void IsThisRight_twoinputs_ReturnNotEnoughInput()
        {
            int a = 3, b = 4;
            Exception ex = Assert.Throws<ArgumentException>(() => SquareCalculatorLib.Calculator.IsThisRight(a, b));
            Console.WriteLine(ex.Message);
            Assert.That(ex.Message, Is.EqualTo("You didn't pass sufficient information about the triangle."));
        }
        [Test]
        public void CalculateSquareOf_fourSidesOfRectangle_ReturnNotSupportedExc()
        {
            int a = 3, b = 4;
            Exception ex = Assert.Throws<Exception>(() => SquareCalculatorLib.Calculator.CalculateSquareOf(a, b));
            Assert.That(ex.Message, Is.EqualTo("Not supported."));
        }
        [Test]
        [TestCase(3, 4, 5, 6)]
        [TestCase(4, 5, 8, 8.18)]
        public void CalculateSquareOf_TriagSides_ReturnSquare(int a, int b, int c, double expected)
        {
            var result = SquareCalculatorLib.Calculator.CalculateSquareOf(a, b, c);
            Assert.That(result, Is.EqualTo(expected).Within(0.01));
        }
        [Test]
        [TestCase(-2)]
        [TestCase(0)]
        public void CalculateSquareOf_ImpossibleRadius_ReturnExceptionNoSuchCirc(int r)
        {
            Exception ex = Assert.Throws<Exception>(() => SquareCalculatorLib.Calculator.CalculateSquareOf(r));
            Assert.That(ex.Message, Is.EqualTo("Such a circle does not exist."));
        }
        [Test]
        [TestCase(-2, -2, -6)]
        [TestCase(2, 2, 6)]
        [TestCase(0, 0, 0)]
        public void CalculateSquareOf_ImpossibleTriagSides_ReturnExceptionNoSuchTriag(int a, int b, int c)
        {
            Exception ex = Assert.Throws<Exception>(() => SquareCalculatorLib.Calculator.CalculateSquareOf(a, b, c));
            Assert.That(ex.Message, Is.EqualTo("Such a triangle does not exist."));
        }
    }
}
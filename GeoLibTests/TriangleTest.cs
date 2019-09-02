using System;
using System.Collections.Generic;
using NUnit.Framework;
using GeoLib.Figures;

namespace GeoLibTests
{
    [TestFixture]
    public class TriangleTest : RandomDoubleProvider
    {
        public static List<Tuple<double[], double>> TriangleTestSequence = new List<Tuple<double[], double>>()
        {
            new Tuple<double[], double>( new double[] { 3, 4, 5 }, 6 ),
            new Tuple<double[], double>( new double[] { 5, 3, 4 }, 6 ),
            new Tuple<double[], double>( new double[] { 5, 4, 3 }, 6 ),

            new Tuple<double[], double>( new double[] { 7, 7, 3 }, 10.256096 ),
            new Tuple<double[], double>( new double[] { 17, 63, 47 }, 156.077505 ),
            new Tuple<double[], double>( new double[] { 0.254, 0.5, 0.323 }, 0.035652 )
        };

        [Test]
        public void Assert1ParConstructorChecksParameters()
        {
            for (int i = 0; i < 10; i++)
            {
                var sideArray = CreateIncorrectSequence();
                Assert.Throws<ArgumentException>(() => new Triangle(sideArray));
            }
        }

        [Test]
        public void Assert3ParConstructorChecksParameters()
        {
            for (int i = 0; i < 10; i++)
            {
                Assert.Throws<ArgumentException>(() => new Triangle(NegativeRandomDouble, NegativeRandomDouble, NegativeRandomDouble));
            }
        }

        [Test]
        public void AssertConstructorChecksIfTriangleExists()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(3, 5, 80));
        }

        [Test]
        public void AssertSquareCountCorrect()
        {
            foreach (var tuple in TriangleTestSequence)
            {
                Assert.AreEqual(tuple.Item2, new Triangle(tuple.Item1).CountSquare(), 1e-6);
            }           
        }

    }
}

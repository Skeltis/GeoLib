using System;
using System.Collections.Generic;
using NUnit.Framework;
using GeoLib.Figures;

namespace GeoLibTests
{
    [TestFixture]
    public class CircleTest : RandomDoubleProvider
    {
        public static List<Tuple<double, double>> CircleTestSequence = new List<Tuple<double, double>>()
        {
            new Tuple<double, double>( 0.12534, 0.0494),
            new Tuple<double, double>( 1, 3.1416),
            new Tuple<double, double>( 4214, 55787761.4575)
        };

        [Test]
        public void AssertConstructorChecksParameter()
        {
            for (int i = 0; i < 10; i++)
            {
                Assert.Throws<ArgumentException>(() => new Circle(NegativeRandomDouble));
            }
        }

        [Test]
        public void AssertSquareCountCorrect()
        {
            foreach (var tuple in CircleTestSequence)
            {
                Assert.AreEqual(tuple.Item2, new Circle(tuple.Item1).CountSquare(), 1e-4);
            }
        }
    }
}

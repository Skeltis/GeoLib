using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GeoLib;

namespace GeoLibTests
{
    [TestFixture]
    public class SquareCalculatorTest
    {
        [Test]
        public void AssertSquareCountBySides()
        {
            foreach (var sequence in CircleTest.CircleTestSequence)
            {
                Assert.AreEqual(sequence.Item2, SquareCalculator.CountSquare(sequence.Item1), 1e-4);
            }

            foreach (var sequence in TriangleTest.TriangleTestSequence)
            {
                Assert.AreEqual(sequence.Item2, SquareCalculator.CountSquare(sequence.Item1), 1e-6);
            }
        }
    }
}

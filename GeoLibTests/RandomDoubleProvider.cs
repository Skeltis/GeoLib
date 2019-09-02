using System;

namespace GeoLibTests
{
    public abstract class RandomDoubleProvider
    {
        protected Random randomizer = new Random();

        protected double NegativeRandomDouble => RandomDouble(-100000, 0);

        protected double RandomDouble(double start, double stop) =>
            randomizer.NextDouble() * (start - stop) + start;

        protected double[] CreateIncorrectSequence() =>
            new double[]
            {
                NegativeRandomDouble,
                NegativeRandomDouble,
                NegativeRandomDouble
            };
    }
}

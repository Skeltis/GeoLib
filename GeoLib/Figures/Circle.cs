using System;

namespace GeoLib.Figures
{
    public class Circle : Figure
    {
        public double Radius { get; private set; }

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Negative values are not supported");

            Radius = radius;
        }

        public override double CountSquare() => Math.PI * Radius * Radius;

    }
}

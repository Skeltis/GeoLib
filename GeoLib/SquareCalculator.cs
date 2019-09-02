using System;
using System.Linq;
using System.Collections;
using System.Diagnostics.Contracts;
using GeoLib.Figures;

namespace GeoLib
{
    public static class SquareCalculator
    {
        private static Hashtable _sideBasedCatalog = new Hashtable()
        {
            { 1, typeof(Circle) },
            { 3, typeof(Triangle) }
        };

        public static double CountCircleSquare(double radius) => 
            (new Circle(radius)).CountSquare();

        public static double CountTriangleSquare(double sideA, double sideB, double sideC) => 
            (new Triangle(sideA, sideB, sideC)).CountSquare();

        public static double CountSquare(params double[] sideValue)
        {
            Contract.Requires(_sideBasedCatalog.ContainsKey(sideValue.Length));

            Type figureType = (Type)_sideBasedCatalog[sideValue.Length];
            Figure figure = (Figure)Activator.CreateInstance(figureType, (from g in sideValue select (g as object)).ToArray());
            return figure.CountSquare();
        }
    }
}

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
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

        public static void SetFigure<T>(int sideCount) where T : Figure
        {
            EnsureConstructorWithSideParamsExist(sideCount);
            _sideBasedCatalog[sideCount] = typeof(T);

            void EnsureConstructorWithSideParamsExist(int sides)
            {
                var constructorsWithDoubles =
                    (from g
                     in typeof(T).GetConstructors()
                     where g.GetParameters().All(par => par.GetType().Equals(typeof(double))) && g.GetParameters().Count() == sides
                     orderby g.GetParameters().Count() ascending
                     select g);
                if (constructorsWithDoubles.Count() < 1)
                    throw new ArgumentException("The figure must have a constructor with " +
                        "the number of parameters of the double type corresponding " +
                        "to the number of sides of the figure");
            }
        }

        public static double CountSquare(params double[] sideValue)
        {
            EnsureFigureStored();

            Type figureType = (Type)_sideBasedCatalog[sideValue.Length];
            Figure figure = (Figure)Activator.CreateInstance(figureType, (from g in sideValue select (g as object)).ToArray());
            return figure.CountSquare();

            void EnsureFigureStored()
            {
                if (!_sideBasedCatalog.ContainsKey(sideValue.Length))
                    throw new KeyNotFoundException($"Required figure  with {sideValue.Length} sides doesn't exist");
            }
        }
    }
}

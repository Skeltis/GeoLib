using System;
using System.Linq;
using System.Collections.Generic;

namespace GeoLib.Figures
{
    public class Triangle : Figure
    {
        private List<double> _sides;
        private delegate double CountSquareDelegate();
        private Func<double> _countSquareFunction;

        public double SideA => _sides[0];
        public double SideB => _sides[1];
        public double SideC => _sides[2];

        public double HalfPerimeter => (SideA + SideB + SideC) / 2;

        public Triangle(double sideA, double sideB, double sideC) : 
            this(new List<double>(3) { sideA, sideB, sideC }) { }

        public Triangle(IEnumerable<double> sides)
        {
            CheckParametersCount();
            CheckParametersArePositive();

            _sides = sides.ToList();
            _sides.Sort();

            CheckTriangleExists();

            if (CheckIfTriangleIsRight())
                _countSquareFunction = CountRightTriangleSquare;
            else
                _countSquareFunction = CountTriangleSquare;

            void CheckParametersCount()
            {
                if (sides.Count() != 3)
                    throw new ArgumentException("Triangle must have 3 sides");
            }
            void CheckParametersArePositive()
            {
                foreach (var side in sides)
                {
                    if (side <= 0)
                        throw new ArgumentException("Negative values are not supported");
                }
            }
            void CheckTriangleExists()
            {
                if (SideC >= SideA + SideB)
                    throw new ArgumentException("Triangle can't exist");
            }
        }

        public override double CountSquare() => _countSquareFunction.Invoke();

        private bool CheckIfTriangleIsRight()
        {
            if (_sides[1] == _sides[2])
                return false;
            return Math.Abs(RevertPifagorEvaluation(SideA, SideB, SideC)) <= double.Epsilon;

            double RevertPifagorEvaluation(double cathet1, double cathet2, double hypotenuse) =>
                cathet1 * cathet1 + cathet2 * cathet2 - hypotenuse * hypotenuse;
        }

        private double CountRightTriangleSquare() => 0.5 * SideA * SideB;

        private double CountTriangleSquare() =>
            Math.Sqrt(HalfPerimeter * (HalfPerimeter - SideA) * (HalfPerimeter - SideB) * (HalfPerimeter - SideC));
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Triangle
    {
        double[] angles = new double[3];
        double[] sides = new double[3];

        public static Triangle CreateByThreeSides(double side1, double side2, double side3)
        {
            if (side1 <= 0 || side2 <= 0 || side3 <= 0)
                throw new ArgumentException("Sides should be greater than zero");
            if ((side1 + side2 <= side3)
                || (side3 + side1 <= side2)
                || (side2 + side3 <= side1))
                throw new ArgumentException("Sum two sides should be greater than other side");

            double[] sides = { side1, side2, side3 };
            double[] angles = new double[3];

            angles[0] = CalculateAngleThroughCosineTheorem(sides[2], sides[1], sides[0]);
            angles[1] = CalculateAngleThroughCosineTheorem(sides[2], sides[0], sides[1]);
            angles[2] = CalculateAngleThroughCosineTheorem(sides[0], sides[1], sides[2]);

            Triangle triangle = new Triangle(sides, angles);

            return triangle;
        }

        public static Triangle CreateByTwoSidesAndAngle(double side1, double side2, double angle)
        {
            if (side1 <= 0 || side2 <= 0 || angle <= 0)
                throw new ArgumentException("Angle and sides should not be less and equal zero");
            if (angle >= Math.PI)
                throw new ArgumentException("Angle should not be greater or equal PI");

            double[] sides = new double[3];
            double[] angles = new double[3];

            sides[0] = side1;
            sides[1] = side2;

            angles[2] = angle;

            sides[2] = CalculateSideThroughCosineTheorem(angles[2], sides[0], sides[1]);

            angles[0] = CalculateAngleThroughCosineTheorem(sides[1], sides[2], sides[0]);
            angles[1] = CalculateAngleThroughCosineTheorem(sides[2], sides[0], sides[1]);

            Triangle triangle = new Triangle(sides, angles);

            return triangle;
        }

        public static Triangle CreateBySideAndTwoAngles(double side, double angle1, double angle2)
        {
            if (side <= 0 || angle1 <= 0 || angle2 <= 0)
                throw new ArgumentException("Side and angles should not be less or equal zero");
            if (angle1 + angle2 >= Math.PI)
                throw new ArgumentException("Sum angles should not be greater than PI");

            double[] sides = new double[3];
            double[] angles = new double[3];

            sides[0] = side;

            angles[2] = angle1;
            angles[1] = angle2;
            angles[0] = Math.PI - angles[1] - angles[2];

            sides[1] = CalculateSideThroughSineTheorem(angles[1], sides[0], angles[0]);
            sides[2] = CalculateSideThroughSineTheorem(angles[2], sides[0], angles[0]);

            Triangle triangle = new Triangle(sides, angles);

            return triangle;
        }

        /// <summary>
        /// It calculate angle through cosine theorem. Angle is between sides side1 and side2 and opposite side side3;
        /// </summary>
        static double CalculateAngleThroughCosineTheorem(double side1, double side2, double side3)
        {
            return Math.Acos((side1 * side1 + side2 * side2 - side3 * side3) / (2 * side1 * side2));
        }

        /// <summary>
        /// It calculate side through cosine theorem. Side is opposite angle. Angle is between sides side1 and side2;
        /// </summary>
        static double CalculateSideThroughCosineTheorem(double angle, double side1, double side2)
        {
            return Math.Sqrt(side1 * side1 + side2 * side2 - 2 * side1 * side2 * Math.Cos(angle));
        }

        /// <summary>
        /// It calculate side through sine theorem. Side is opposite angle. Side1 is adjacent side. Angle1 is opposite side1;
        /// </summary>
        static double CalculateSideThroughSineTheorem(double angle, double side1, double angle1)
        {
            return side1 * Math.Sin(angle) / Math.Sin(angle1);
        }

        public Triangle(double[] sides, double[] angles)
        {
            if (sides == null || angles == null)
                throw new ArgumentNullException("Sides and angles should not be null");
            if (sides.Length != 3 || angles.Length != 3)
                throw new ArgumentException("Count sides and angles should be equal three");
            for (int i = 0; i < 3; i++)
            {
                if (sides[i] <= 0 || angles[i] <= 0)
                    throw new ArgumentException("Side or angle should not be less or equal zero");
            }
            if (Math.Abs(angles[0] + angles[1] + angles[2] - Math.PI) > 0.0001)
                throw new ArgumentException("Sum angles should be equal PI");
            if ((sides[0] + sides[1] <= sides[2])
                || (sides[2] + sides[0] <= sides[1])
                || (sides[1] + sides[2] <= sides[0]))
                throw new ArgumentException("Sum two sides should be greater than other side");

            this.sides = sides;
            this.angles = angles;
        }

        public double GetSquare()
        {
            double semiperimeter = (this.sides[0] + this.sides[1] + this.sides[2]) / 2;

            return Math.Sqrt(semiperimeter * (semiperimeter - this.sides[0]) * (semiperimeter - this.sides[1]) * (semiperimeter - this.sides[2]));
        }
        public double[] GetSides()
        {
            return this.sides;
        }
        public double[] GetAngles()
        {
            return this.angles;
        }
    }
}

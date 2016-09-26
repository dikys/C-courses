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
        
        public Triangle(double[] sides)
        {
            this.sides = sides;

            this.angles[0] = CalculateAngleBeetwenBAndC(this.sides[1], this.sides[2], this.sides[0]);
            this.angles[1] = CalculateAngleBeetwenBAndC(this.sides[2], this.sides[0], this.sides[1]);
            this.angles[2] = CalculateAngleBeetwenBAndC(this.sides[0], this.sides[1], this.sides[2]);
        }
        public Triangle(double[] sides, double angle)
        {
            this.sides[0] = sides[0];
            this.sides[1] = sides[1];

            this.angles[2] = angle;

            this.sides[2] = CalculateSideOppositeAngleThCos(this.angles[2], this.sides[0], this.sides[1]);
            
            this.angles[0] = CalculateAngleBeetwenBAndC(this.sides[1], this.sides[2], this.sides[0]);
            this.angles[1] = CalculateAngleBeetwenBAndC(this.sides[2], this.sides[0], this.sides[1]);
        }
        public Triangle(double side, double[] angles)
        {
            this.sides[0] = side;

            this.angles[2] = angles[0];
            this.angles[1] = angles[1];
            this.angles[0] = Math.PI - this.angles[1] - this.angles[2];

            this.sides[1] = CalculateSideOppositeAngleThSin(this.angles[1], this.sides[0], this.angles[0]);
            this.sides[2] = CalculateSideOppositeAngleThSin(this.angles[2], this.sides[0], this.angles[0]);
        }
        
        double CalculateAngleBeetwenBAndC(double b, double c, double a)
        {
            return Math.Acos((b * b + c * c - a * a) / (2 * b * c));
        }
        // angle beetwen b and c
        double CalculateSideOppositeAngleThCos(double angle, double b, double c)
        {
            return Math.Sqrt(b * b + c * c - 2 * b * c * Math.Cos(angle));
        }
        // sideA - adjacent side, angleA - angle opposite sideA
        double CalculateSideOppositeAngleThSin(double angle, double sideA, double angleA)
        {
            return sideA * Math.Sin(angle) / Math.Sin(angleA);
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

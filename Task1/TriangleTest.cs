using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometry.Test
{
    [TestClass]
    public class TriangleTest
    {
        double tolerance = 0.0001;

        double[] sidesRightTriangle = new double[] { 3, 4, 5 };
        double[] anglesRightTriangle = new double[] { Math.Asin(0.6), Math.Asin(0.8), Math.PI / 2 };
        double squareRightTriangle = 6;

        double[] sidesObtuseTriangle = new double[] { 9, 5, 6 };
        double[] anglesObtuseTriangle = new double[] { 1.910633, 0.551285, 0.679673 };
        double squareObtuseTriangle = 14.142135;

        double[] sidesAcuteTriangle = new double[] { 4, 5, 6 };
        double[] anglesAcuteTriangle = new double[] { 0.722734, 0.973389, 1.445468 };
        double squareAcuteTriangle = 9.921567;

        void CheckTriangle(Triangle triangle, double[] expectedSides, double[] expectedAngles, double expectedSquare)
        {
            for (int i = 0; i < 3; i++)
            {
                Assert.IsTrue(Math.Abs(triangle.GetSides()[i] - expectedSides[i]) < tolerance);
                Assert.IsTrue(Math.Abs(triangle.GetAngles()[i] - expectedAngles[i]) < tolerance);
            }

            Assert.IsTrue(Math.Abs(triangle.GetSquare() - expectedSquare) < tolerance);
        }

        [TestMethod]
        public void InitializationTriangleAcrossThreeSides()
        {
            Triangle triangle = new Triangle(sidesRightTriangle);
            CheckTriangle(triangle, sidesRightTriangle, anglesRightTriangle, squareRightTriangle);

            triangle = new Triangle(sidesObtuseTriangle);
            CheckTriangle(triangle, sidesObtuseTriangle, anglesObtuseTriangle, squareObtuseTriangle);

            triangle = new Triangle(sidesAcuteTriangle);
            CheckTriangle(triangle, sidesAcuteTriangle, anglesAcuteTriangle, squareAcuteTriangle);
        }

        [TestMethod]
        public void InitializationTriangleAcrossTwoSidesAndAngle()
        {
            Triangle triangle = new Triangle(new double[] { sidesRightTriangle[0], sidesRightTriangle[1] }, anglesRightTriangle[2]);
            CheckTriangle(triangle, sidesRightTriangle, anglesRightTriangle, squareRightTriangle);

            triangle = new Triangle(new double[] { sidesObtuseTriangle[0], sidesObtuseTriangle[1] }, anglesObtuseTriangle[2]);
            CheckTriangle(triangle, sidesObtuseTriangle, anglesObtuseTriangle, squareObtuseTriangle);

            triangle = new Triangle(new double[] { sidesAcuteTriangle[0], sidesAcuteTriangle[1] }, anglesAcuteTriangle[2]);
            CheckTriangle(triangle, sidesAcuteTriangle, anglesAcuteTriangle, squareAcuteTriangle);
        }

        [TestMethod]
        public void InitializationTriangleAcrossSideAndTwoAngle()
        {
            Triangle triangle = new Triangle(sidesRightTriangle[0], new double[] { anglesRightTriangle[2], anglesRightTriangle[1] });
            CheckTriangle(triangle, sidesRightTriangle, anglesRightTriangle, squareRightTriangle);

            triangle = new Triangle(sidesObtuseTriangle[0], new double[] { anglesObtuseTriangle[2], anglesObtuseTriangle[1] });
            CheckTriangle(triangle, sidesObtuseTriangle, anglesObtuseTriangle, squareObtuseTriangle);

            triangle = new Triangle(sidesAcuteTriangle[0], new double[] { anglesAcuteTriangle[2], anglesAcuteTriangle[1] });
            CheckTriangle(triangle, sidesAcuteTriangle, anglesAcuteTriangle, squareAcuteTriangle);
        }
        
    }
}

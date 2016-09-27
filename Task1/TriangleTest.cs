using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometry.Test
{
    [TestClass]
    public class TriangleTest
    {
        static double tolerance = 0.0001;

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_SidesOrAnglesIsNull_ArgumentNullException()
        {
            Triangle triangle = new Triangle(null, null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_CountSidesOrAnglesNotEqualThree_ArgumentException()
        {
            Triangle triangle = new Triangle(new double[2] { 1, 2 }, new double[4] { 1, 2, 3, 4 });
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_SideOrAngleLessOrEqualZero_ArgumentException()
        {
            Triangle triangle = new Triangle(new double[3] { -1, 0, -2 }, new double[3] { 0, -3, -1 });
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_SumAnglesNotEqualPI_ArgumentException()
        {
            Triangle triangle = new Triangle(new double[3] { 3, 4, 5 }, new double[3] { Math.PI, 1, 1 });
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_SumTwoSideLessOrEqualOtherSide_ArgumentException()
        {
            Triangle triangle = new Triangle(new double[3] { 3, 4, 10 }, new double[3] { Math.PI / 3, Math.PI / 3, Math.PI / 3 });
        }

        [TestMethod]
        public void CreateTriangleAcrossThreeSides_EqualSides_EquilateralTriangle()
        {
            Triangle triangle = Triangle.CreateTriangleAcrossThreeSides(100, 100, 100);
            double[] sidesTriangle = triangle.GetSides();
            double[] anglesTriangle = triangle.GetAngles();

            Assert.IsTrue(sidesTriangle[0] == sidesTriangle[1] && sidesTriangle[1] == sidesTriangle[2]);
            Assert.IsTrue(anglesTriangle[0] == anglesTriangle[1] && anglesTriangle[1] == anglesTriangle[2]);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTriangleAcrossThreeSides_SideLessOrEqualZero_ArgumentException()
        {
            Triangle triangle = Triangle.CreateTriangleAcrossThreeSides(-1, -1, -1);
            Triangle triangle2 = Triangle.CreateTriangleAcrossThreeSides(0, 0, 0);
            Triangle triangle3 = Triangle.CreateTriangleAcrossThreeSides(0, -1, 0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTriangleAcrossThreeSides_SumTwoSideLessOrEqualOtherSide_ArgumentException()
        {
            Triangle triangle = Triangle.CreateTriangleAcrossThreeSides(5, 1, 1);
            Triangle triangle2 = Triangle.CreateTriangleAcrossThreeSides(2, 4, 2);
            Triangle triangle3 = Triangle.CreateTriangleAcrossThreeSides(2, 3, 5);
        }

        [TestMethod]
        public void CreateTriangleAcrossTwoSidesAndAngleBeetwen_RightAngle_RightTriangle()
        {
            Triangle triangle = Triangle.CreateTriangleAcrossTwoSidesAndAngleBeetwen(3, 4, Math.PI / 2);
            double[] sidesTriangle = triangle.GetSides();
            double[] anglesTriangle = triangle.GetAngles();
            
            Assert.IsTrue(Math.Abs(Math.Pow(sidesTriangle[0], 2) + Math.Pow(sidesTriangle[1], 2) - Math.Pow(sidesTriangle[2], 2)) <= tolerance
                || Math.Abs(Math.Pow(sidesTriangle[2], 2) + Math.Pow(sidesTriangle[0], 2) - Math.Pow(sidesTriangle[1], 2)) <= tolerance
                || Math.Abs(Math.Pow(sidesTriangle[1], 2) + Math.Pow(sidesTriangle[0], 2) - Math.Pow(sidesTriangle[0], 2)) <= tolerance);
            Assert.IsTrue(Math.Abs(Math.Atan(3.0 / 4) - anglesTriangle[0]) <= tolerance
                || Math.Abs(Math.Atan(3.0 / 4) - anglesTriangle[1]) <= tolerance
                || Math.Abs(Math.Atan(3.0 / 4) - anglesTriangle[2]) <= tolerance);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTriangleAcrossTwoSidesAndAngleBeetwen_SideOrAngleLessOrEqualZero_ArgumentException()
        {
            Triangle triangle = Triangle.CreateTriangleAcrossTwoSidesAndAngleBeetwen(-1, -1, -1);
            Triangle triangle2 = Triangle.CreateTriangleAcrossTwoSidesAndAngleBeetwen(0, 0, 0);
            Triangle triangle3 = Triangle.CreateTriangleAcrossTwoSidesAndAngleBeetwen(0, -1, 0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTriangleAcrossTwoSidesAndAngleBeetwen_AngleGreaterOrEqualPi_ArgumentException()
        {
            Triangle triangle = Triangle.CreateTriangleAcrossTwoSidesAndAngleBeetwen(1, 2, Math.PI);
            Triangle triangle2 = Triangle.CreateTriangleAcrossTwoSidesAndAngleBeetwen(1, 2, Math.PI + 1);
        }

        [TestMethod]
        public void CreateTriangleAcrossSideAndAdjacentAngles_EqualAngles_IsoscelesTriangle()
        {
            Triangle triangle = Triangle.CreateTriangleAcrossSideAndAdjacentAngles(5, Math.PI / 6, Math.PI / 6);
            double[] sidesTriangle = triangle.GetSides();

            Assert.IsTrue(Math.Abs(sidesTriangle[0] - sidesTriangle[1]) <= tolerance
                || Math.Abs(sidesTriangle[0] - sidesTriangle[2]) <= tolerance
                || Math.Abs(sidesTriangle[1] - sidesTriangle[2]) <= tolerance);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTriangleAcrossSideAndAdjacentAngles_SideOrAngleLessOrEqualZero_ArgumentException()
        {
            Triangle triangle = Triangle.CreateTriangleAcrossSideAndAdjacentAngles(-1, -1, -1);
            Triangle triangle2 = Triangle.CreateTriangleAcrossSideAndAdjacentAngles(0, 0, 0);
            Triangle triangle3 = Triangle.CreateTriangleAcrossSideAndAdjacentAngles(0, -1, 0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTriangleAcrossSideAndAdjacentAngles_SumAnglesGreaterOrEqualThanPi_ArgumentException()
        {
            Triangle trianlge = Triangle.CreateTriangleAcrossSideAndAdjacentAngles(5, Math.PI / 2, Math.PI / 2);
            Triangle trianlge2 = Triangle.CreateTriangleAcrossSideAndAdjacentAngles(5, Math.PI, Math.PI / 2);
        }

        [TestMethod]
        public void GetSquare_EgyptianTriangle_Six()
        {
            Triangle triangle = Triangle.CreateTriangleAcrossThreeSides(3, 4, 5);

            Assert.IsTrue(Math.Abs(6 - triangle.GetSquare()) <= tolerance);
        }
    }
}

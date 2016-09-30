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
        public void Constructor_SidesOrAnglesIsNull_ThrowArgumentNullException()
        {
            Triangle triangle = new Triangle(null, null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_CountSidesOrAnglesNotEqualThree_ThrowArgumentException()
        {
            Triangle triangle = new Triangle(new double[2] { 1, 2 }, new double[4] { 1, 2, 3, 4 });
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_SideOrAngleLessOrEqualZero_ThrowArgumentException()
        {
            Triangle triangle = new Triangle(new double[3] { -1, 0, -2 }, new double[3] { 0, -3, -1 });
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_SumAnglesNotEqualPI_ThrowArgumentException()
        {
            Triangle triangle = new Triangle(new double[3] { 3, 4, 5 }, new double[3] { Math.PI, 1, 1 });
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_SumTwoSideLessOrEqualOtherSide_ThrowArgumentException()
        {
            Triangle triangle = new Triangle(new double[3] { 3, 4, 10 }, new double[3] { Math.PI / 3, Math.PI / 3, Math.PI / 3 });
        }

        [TestMethod]
        public void CreateByThreeSides_EqualSides_EquilateralTriangle()
        {
            Triangle triangle = Triangle.CreateByThreeSides(100, 100, 100);
            double[] sidesTriangle = triangle.GetSides();
            double[] anglesTriangle = triangle.GetAngles();
            
            Assert.AreEqual(sidesTriangle[0], sidesTriangle[1], tolerance);
            Assert.AreEqual(sidesTriangle[1], sidesTriangle[2], tolerance);
            
            Assert.AreEqual(anglesTriangle[0], anglesTriangle[1], tolerance);
            Assert.AreEqual(anglesTriangle[1], anglesTriangle[2], tolerance);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateByThreeSides_SideLessOrEqualZero_ThrowArgumentException()
        {
            Triangle triangle = Triangle.CreateByThreeSides(-1, -1, -1);
            Triangle triangle2 = Triangle.CreateByThreeSides(0, 0, 0);
            Triangle triangle3 = Triangle.CreateByThreeSides(0, -1, 0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateByThreeSides_SumTwoSideLessOrEqualOtherSide_ThrowArgumentException()
        {
            Triangle triangle = Triangle.CreateByThreeSides(5, 1, 1);
            Triangle triangle2 = Triangle.CreateByThreeSides(2, 4, 2);
            Triangle triangle3 = Triangle.CreateByThreeSides(2, 3, 5);
        }

        [TestMethod]
        public void CreateByTwoSidesAndAngle_RightAngle_RightTriangle()
        {
            Triangle triangle = Triangle.CreateByTwoSidesAndAngle(3, 4, Math.PI / 2);
            double[] sidesTriangle = triangle.GetSides();
            double[] anglesTriangle = triangle.GetAngles();
            
            Assert.IsTrue(Math.Abs(Math.Pow(sidesTriangle[0], 2) + Math.Pow(sidesTriangle[1], 2) - Math.Pow(sidesTriangle[2], 2)) <= tolerance);
            Assert.IsTrue(Math.Abs(Math.Atan(3.0 / 4) - anglesTriangle[0]) <= tolerance);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateByTwoSidesAndAngle_SideOrAngleLessOrEqualZero_ThrowArgumentException()
        {
            Triangle triangle = Triangle.CreateByTwoSidesAndAngle(-1, -1, -1);
            Triangle triangle2 = Triangle.CreateByTwoSidesAndAngle(0, 0, 0);
            Triangle triangle3 = Triangle.CreateByTwoSidesAndAngle(0, -1, 0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateByTwoSidesAndAngle_AngleGreaterOrEqualPi_ThrowArgumentException()
        {
            Triangle triangle = Triangle.CreateByTwoSidesAndAngle(1, 2, Math.PI);
            Triangle triangle2 = Triangle.CreateByTwoSidesAndAngle(1, 2, Math.PI + 1);
        }

        [TestMethod]
        public void CreateBySideAndTwoAngles_EqualAngles_ThrowIsoscelesTriangle()
        {
            Triangle triangle = Triangle.CreateBySideAndTwoAngles(5, Math.PI / 6, Math.PI / 6);
            double[] sidesTriangle = triangle.GetSides();
            
            Assert.IsTrue(Math.Abs(sidesTriangle[1] - sidesTriangle[2]) <= tolerance);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBySideAndTwoAngles_SideOrAngleLessOrEqualZero_ThrowArgumentException()
        {
            Triangle triangle = Triangle.CreateBySideAndTwoAngles(-1, -1, -1);
            Triangle triangle2 = Triangle.CreateBySideAndTwoAngles(0, 0, 0);
            Triangle triangle3 = Triangle.CreateBySideAndTwoAngles(0, -1, 0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBySideAndTwoAngles_SumAnglesGreaterOrEqualThanPi_ThrowArgumentException()
        {
            Triangle trianlge = Triangle.CreateBySideAndTwoAngles(5, Math.PI / 2, Math.PI / 2);
            Triangle trianlge2 = Triangle.CreateBySideAndTwoAngles(5, Math.PI, Math.PI / 2);
        }

        [TestMethod]
        public void GetSquare_EgyptianTriangle_Six()
        {
            Triangle triangle = Triangle.CreateByThreeSides(3, 4, 5);

            Assert.AreEqual(6, triangle.GetSquare(), tolerance);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using FiguresLib;

namespace FiguresLibTest
{
    [TestClass]
    public class FigureCreatorTest
    {
        public static IEnumerable<object[]> GetBadTrianglesData()
        {
            foreach (string line in File.ReadLines(@"Resources\BadTriangles.csv").Skip(1))
            {
                var culture = CultureInfo.InvariantCulture;
                string[] items = line.Split(';');
                var A = double.Parse(items[0], culture);
                var B = double.Parse(items[1], culture);
                var C = double.Parse(items[2], culture);
                yield return new object[] { A, B, C };
            }
        }

        public static IEnumerable<object[]> GetBadCirclesData()
        {
            foreach (string line in File.ReadLines(@"Resources\BadCircles.csv").Skip(1))
            {
                yield return new object[] { double.Parse(line, CultureInfo.InvariantCulture) };
            }
        }

        public static IEnumerable<object[]> GetRightTriangleSides()
        {
            foreach (string line in File.ReadLines(@"Resources\RightTriangleData.csv").Skip(1))
            {
                var culture = CultureInfo.InvariantCulture;
                string[] items = line.Split(';');
                var Leg1 = double.Parse(items[0], culture);
                var Leg2 = double.Parse(items[1], culture);
                var Hypotenuse = double.Parse(items[2], culture);
                yield return new object[] { Leg1, Leg2, Hypotenuse };
            }
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DynamicData(nameof(GetBadTrianglesData), DynamicDataSourceType.Method)] 
        public void InputBadTrinagleSidesOutputException(double a, double b, double c )
        {
            var creator = new FigureCreator();
            var triangle = creator.CreateTriangle(a, b, c);
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DynamicData(nameof(GetBadCirclesData), DynamicDataSourceType.Method)]
        public void InputBadCircleRadiusOutputException(double radius)
        {
            var creator = new FigureCreator();
            var circle = creator.CreateCircle(radius);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetRightTriangleSides), DynamicDataSourceType.Method)]
        public void InputRightTriangleSidesOutputRightTriangle(double leg1, double leg2, double hypotenuse)
        {
            var creator = new FigureCreator();
            var triangle = creator.CreateTriangle(leg1, leg2, hypotenuse);
            Assert.IsInstanceOfType(triangle, typeof(RightTriangle));
        }
    }
}

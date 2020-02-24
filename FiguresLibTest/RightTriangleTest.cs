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
    public class RightTriangleTest
    {
        public static IEnumerable<object[]> GetRightTriangleTestData()
        {
            foreach (string line in File.ReadLines(@"Resources\RightTriangleData.csv").Skip(1))
            {
                var culture = CultureInfo.InvariantCulture;
                string[] items = line.Split(';');
                var Leg1 = double.Parse(items[0], culture);
                var Leg2 = double.Parse(items[1], culture);
                var Hypotenuse = double.Parse(items[2], culture);
                var expected = double.Parse(items[3], culture);
                yield return new object[] { Leg1, Leg2, Hypotenuse, expected };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetRightTriangleTestData), DynamicDataSourceType.Method)]
        public void InputSidesOutputArea(double leg1, double leg2, double hypotenuse, double expected)
        {
            var triangle = new RightTriangle(leg1, leg2, hypotenuse);
            var actual = triangle.GetArea();
            Assert.AreEqual(expected, actual, 1E-4);
        }
    }
}

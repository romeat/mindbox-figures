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
    public class TriangleTest
    {
        public static IEnumerable<object[]> GetTriangleTestData()
        {
            foreach (string line in File.ReadLines(@"Resources\TriangleData.csv").Skip(1))
            {
                var culture = CultureInfo.InvariantCulture;
                string[] items = line.Split(';');
                var A = double.Parse(items[0], culture);
                var B = double.Parse(items[1], culture);
                var C = double.Parse(items[2], culture);
                var expected = double.Parse(items[3], culture);
                yield return new object[] { A, B, C, expected };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTriangleTestData), DynamicDataSourceType.Method)]
        public void InputSidesOutputArea(double a, double b, double c, double expected)
        {
            var triangle = new Triangle(a,b,c);
            var actual = triangle.GetArea();
            Assert.AreEqual(expected, actual, 1E-4);
        }
    }
}

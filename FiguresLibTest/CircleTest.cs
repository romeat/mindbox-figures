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
    public class CircleTest
    {
        public static IEnumerable<object[]> GetCircleTestData()
        {
            foreach (string line in File.ReadLines(@"Resources\CircleData.csv").Skip(1))
            {
                var culture = CultureInfo.InvariantCulture;
                string[] items = line.Split(';');
                var radius = double.Parse(items[0], culture);
                var expected = double.Parse(items[1], culture);
                yield return new object[] { radius, expected };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetCircleTestData), DynamicDataSourceType.Method)]
        public void InputRadiusOutputArea(double radius, double expected)
        {
            var circle = new Circle(radius);
            var actual = circle.GetArea();
            Assert.AreEqual(expected, actual, 1E-4);
        }
    }
}

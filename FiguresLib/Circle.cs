using System;

namespace FiguresLib
{
    public class Circle : IArea
    {
        public double Radius { get; }

        internal Circle(double radius)
        {
            Radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}

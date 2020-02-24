using System;

namespace FiguresLib
{
    public class Triangle : IArea
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }

        internal Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public virtual double GetArea()
        {
            double halfPerimeter = (A + B + C) / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - A) * (halfPerimeter - B) * (halfPerimeter - C));
        }
    }
}

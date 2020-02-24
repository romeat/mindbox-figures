using System;
using System.Collections.Generic;

namespace FiguresLib
{
    public class FigureCreator
    {
        public Triangle CreateTriangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides can't have a non-positive value");
            }

            var sides = new List<double> { a, b, c };
            sides.Sort();

            // При равенстве получается вырожденный треугольник с нулевой площадью;
            // не знаю, имеет ли смысл его создавать, но это тоже треугольник
            if (sides[2] > sides[0] + sides[1])
            {
                throw new ArgumentException("Sides can't form a triangle");
            }

            if (sides[2]*sides[2] == sides[0]*sides[0] + sides[1]*sides[1])
            {
                return new RightTriangle(sides[0], sides[1], sides[2]); 
            }
            return new Triangle(sides[0], sides[1], sides[2]);
        }

        public Circle CreateCircle(double radius)
        {
            // То же самое с вырожденной окружностью
            if (radius < 0)
            {
                throw new ArgumentException("Radius can't have a negative value");
            }
            return new Circle(radius);
        }
    }
}

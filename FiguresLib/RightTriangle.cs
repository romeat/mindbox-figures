
namespace FiguresLib
{
    public class RightTriangle : Triangle
    {
        internal RightTriangle(double leg1, double leg2, double hypotenuse) : base(leg1, leg2, hypotenuse) { }

        public override double GetArea()
        {
            return A * B / 2;
        }
    }
}

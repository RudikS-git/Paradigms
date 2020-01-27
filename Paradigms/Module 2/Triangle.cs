using System;

namespace Paradigms.Module_2
{
    public class Triangle : Shape
    {
        double _bottom { get; set; }
        double _b { get; set; }
        double _c { get; set; }

        public Triangle(double bottom, double b, double c)
        {
            _bottom = bottom;
            _b = b;
            _c = c;
        }

        public override double CalcArea()
        {
            double p = CalcPerimeter() / 2;
            return Math.Sqrt(p * (p - _bottom) * (p - _b) * (p - _c));
        }

        public override double CalcPerimeter() =>
            _bottom + _b + _c;
    }
}

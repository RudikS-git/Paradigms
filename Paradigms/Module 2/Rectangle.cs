using System;
using System.Collections.Generic;
using System.Text;

namespace Paradigms.Module_2
{
    public class Rectangle : Shape
    {
        double _a { get; set; }
        double _b { get; set; }

        public Rectangle(double a, double b)
        {
            _a = a;
            _b = b;
        }

        public override double CalcArea() =>
            _a * _b;

        public override double CalcPerimeter() =>
            2* ( _a + _b );
    }
}

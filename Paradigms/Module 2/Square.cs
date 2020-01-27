using System;
using System.Collections.Generic;
using System.Text;

namespace Paradigms.Module_2
{
    public class Square : Shape
    {
        double _a { get; set; }

        public Square(double a)
        {
            _a= a;
        }

        public override double CalcArea() =>
            Math.Pow(_a, 2);

        public override double CalcPerimeter() =>
            4*_a;
    }
}

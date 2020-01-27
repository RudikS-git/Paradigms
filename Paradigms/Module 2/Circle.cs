using System;

namespace Paradigms.Module_2
{
    public class Circle : Shape 
    {
        double _radius { get; set; }

        public Circle(double radius)
        {
            _radius = radius;
        }

        public override double CalcArea() =>
            Math.PI * Math.Pow(_radius, 2);

        public override double CalcPerimeter() =>
            2 * Math.PI * _radius;
    }
}

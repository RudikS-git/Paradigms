using System;
using System.Collections.Generic;
using System.Text;

namespace Paradigms.Module_2
{
    public abstract class Shape
    {
        public Color color { get; set; }
        public abstract double CalcArea();
        public abstract double CalcPerimeter();
    }
}

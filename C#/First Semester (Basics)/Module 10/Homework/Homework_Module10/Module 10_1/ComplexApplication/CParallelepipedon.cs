using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexApplication
{
    //Параллелепипед прямоугольный
    class CParallelepipedon : Body3D
    {
        public CParallelepipedon():this(0)
        {

        }
        public CParallelepipedon(double _a, double _b = 0, double _c = 0)
        {
            A = _a;
            B = _b;
            C = _c;
        }
        public double A
        {
            get; set;
        }
        public double B
        {
            get; set;
        }
        public double C
        {
            get; set;
        }

        public override double Area()
        {
            return 2 * ((A * B) + (B * C) + (A * C));
        }

        public override double SummOfLengthOfEdges()
        {
            return 4 * (A + B + C);
        }

        public override double Volume()
        {
            return A * B * C;
        }

        public override string ToString()
        {
            String str = String.Format("\nПлощадь поверхности правильного параллелепипеда = {0};\nОбъем правильного параллелепипеда = {1}\n\n", Area(), Volume());
            return str;
        }
    }
}

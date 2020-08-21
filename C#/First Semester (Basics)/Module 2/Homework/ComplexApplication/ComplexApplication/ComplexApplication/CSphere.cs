using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexApplication
{
    //Шар
    class CSphere : Body3D
    {
        public CSphere():this(0)
        {
        }
        public CSphere(double _Radius)
        {
            Radius = _Radius;
        }
        public double Radius
        {
            get; set;
        }
        public override double Area()
        {
            return 4 * Math.PI * Math.Pow(Radius, 2);
        }

        public override double SummOfLengthOfEdges()
        {
            return 0;
        }

        public override double Volume()
        {
            return (4 / 3) * Math.PI * Math.Pow(Radius, 3);
        }

        public override string ToString()
        {
            String str = String.Format("\nПлощадь поверхности шара = {0};\nОбъем шара = {1}\n\n", Area(), Volume());
            return str;
        }
    }
}

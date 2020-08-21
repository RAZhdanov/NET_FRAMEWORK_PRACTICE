using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexApplication
{
    //Тетраэдр
    class CTetrahedron : Body3D
    {
        public CTetrahedron():this(0)
        {            
        }
        public CTetrahedron(double _a)
        {
            A = _a;
        }
        public double A
        {
            get; set;
        }
        public override double Area()
        {
            return Math.Pow(A, 2) * Math.Sqrt(3);
        }

        public override double SummOfLengthOfEdges()
        {
            return A * 6;
        }

        public override double Volume()
        {
            return Math.Pow(A, 3) * (Math.Sqrt(2) / 12);
        }

        public override string ToString()
        {
            String str = String.Format("\nПлощадь поверхности тетраэдра = {0};\nОбъем тетраэдра = {1}\n\n", Area(), Volume());
            return str;
        }
    }
}

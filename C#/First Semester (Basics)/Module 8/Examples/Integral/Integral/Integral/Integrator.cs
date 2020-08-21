using System;

namespace Integral
{
    public class Integrator
    {
        public delegate double RealFunc(double x);

        public double Integrate(double a, double b, int n, RealFunc f)
        {
            double dx = (b - a) / n, res = 0.0;
            for (int j = 0; j < n; j++)
                res += f(a + j * dx) * dx;
            return res;
        }

        public double IntegrateUsingStandartDelegate(double a, double b, int n, Func<double, double> f)
        {
            double dx = (b - a) / n, res = 0.0;
            for (int j = 0; j < n; j++)
                res += f(a + j * dx) * dx;
            return res;
        }
    }
}

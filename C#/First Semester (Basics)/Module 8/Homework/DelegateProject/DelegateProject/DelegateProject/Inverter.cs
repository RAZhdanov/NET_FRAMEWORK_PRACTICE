using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateProject
{
    class Inverter
    {
        //Событие, информирующее о достигнутой точности вычисления y на данный момент
        public event EventHandler<VisualInverseFunction> Y_Precision_Event;

        public double Method(double find_y, double x1, double x2, Func<double, double> func, double epsilon)
        {
            double middle_point = ((x1 + x2) / 2.0);

            while (Math.Abs(x2 - x1) > epsilon)
            {
                OnShowCurrentPrecision(Math.Abs(x2 - x1));
                if (func(middle_point) > find_y)
                {
                    x2 = middle_point;
                }
                else
                {
                    x1 = middle_point;
                }
                middle_point = ((x1 + x2) / 2.0);
                
            }
            return middle_point;
        }
        
        private void OnShowCurrentPrecision(double precision)
        {
            EventHandler<VisualInverseFunction> handler = Y_Precision_Event; // для потокобезопасности
            if (handler != null)
                handler(this, new VisualInverseFunction(precision));
        }
    }
}

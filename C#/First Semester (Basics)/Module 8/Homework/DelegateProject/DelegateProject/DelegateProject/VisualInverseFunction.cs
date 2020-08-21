using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace DelegateProject
{
    class VisualInverseFunction : EventArgs
    {
        public VisualInverseFunction(double precision)
        {
            m_precision = precision;
        }
        public double m_precision { get; private set; }
    }
}

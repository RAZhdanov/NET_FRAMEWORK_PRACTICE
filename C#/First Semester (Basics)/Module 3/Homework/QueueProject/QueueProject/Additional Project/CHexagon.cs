using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Additional_Project
{
    class CHexagon : CShape, Interfaces.IPoint
    {
        public int Point {
            get
            {
                return 6;
            }
        }
    }
}

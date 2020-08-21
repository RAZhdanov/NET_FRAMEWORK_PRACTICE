using Client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public static class ComplexExtention
    {
        public static string Print(this Complex complex)
        {
            return complex.Re.ToString() + ((complex.Im < 0) ? " - " + (-complex.Im).ToString() : " + " + complex.Im.ToString())+"i";
        }

    }
}

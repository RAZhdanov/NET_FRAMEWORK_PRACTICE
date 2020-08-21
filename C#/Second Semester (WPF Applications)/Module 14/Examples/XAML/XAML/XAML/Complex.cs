using System;

namespace XAML
{
    public class Complex
    {
        public double Re { get; set; }
        public double Im { get; set; }

        public override string ToString()
        {
            return string.Format("{0} + {1}i", Re, Im);
        }
    }
}

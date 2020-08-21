namespace ListDemo
{
    public class Complex
    {
        public Complex(double re = 0, double im = 0)
        {
            Re = re;
            Im = im;
        }

        public double Re { get; set; }
        public double Im { get; set; }

        public override string ToString()
        {
            return $"{Re}+{Im}i";
        }
    }
}

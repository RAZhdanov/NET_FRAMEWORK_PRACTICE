using System;
using System.Windows.Markup;

namespace MarkupExtensionDemo
{
    [MarkupExtensionReturnType(typeof(string))]
    public class SumExtension : MarkupExtension
    {
        public SumExtension()
        {
        }
        public SumExtension(int x)
        {
            X = x;
            Y = 10;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return (X + Y).ToString();
        }
    }
}

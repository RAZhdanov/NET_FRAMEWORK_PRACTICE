using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Module20.Models
{
    public class CPlay : Shape
    {
        PathGeometry m_pathGeometry = new PathGeometry();
        public CPlay()
        {
            Stroke = Brushes.Black;
            Stretch = Stretch.Fill;
            PathFigure figure = new PathFigure();


        }

        protected override Geometry DefiningGeometry => throw new NotImplementedException();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Modelu19_1.Models
{
    public class CFivePointStar : Shape
    {
        protected PathGeometry m_PathGeometry; //PathGeometry позволяет создавать более сложные по характеру геометрии.
        PathFigure m_PathFigure; //PathGeometry содержит один или несколько компонентов PathFigure.
        PolyLineSegment m_PolyLineSegment; //PolyLineSegment задает сегмент из нескольких линий

        public CFivePointStar()
        {
            m_PathGeometry = new PathGeometry();
            m_PathFigure = new PathFigure();
            m_PolyLineSegment = new PolyLineSegment();
            m_PathGeometry.Figures.Add(m_PathFigure);
            Stretch = Stretch.Fill;

            double r = SizeR;
            double x = Center.X;
            double y = Center.Y;
            double sn36 = Math.Sin(36.0 * Math.PI / 180.0);
            double sn72 = Math.Sin(72.0 * Math.PI / 180.0);
            double cs36 = Math.Cos(36.0 * Math.PI / 180.0);
            double cs72 = Math.Cos(72.0 * Math.PI / 180.0);

            //Создадим программно координатную плоскость с использованием объекта PathGeometry:
            m_PathFigure.StartPoint = new Point(x, y - r);
            m_PolyLineSegment.Points.Add(new Point(x + r * sn36, y + r * cs36));
            m_PolyLineSegment.Points.Add(new Point(x - r * sn72, y - r * cs72));
            m_PolyLineSegment.Points.Add(new Point(x + r * sn72, y - r * cs72));
            m_PolyLineSegment.Points.Add(new Point(x - r * sn36, y + r * cs36));
            m_PolyLineSegment.Points.Add(new Point(x, y - r));
            m_PathFigure.Segments.Add(m_PolyLineSegment);
            m_PathFigure.IsClosed = true;
            m_PathGeometry.FillRule = FillRule.Nonzero;
        }

        //Specify the center of the star
        public static readonly DependencyProperty CenterProperty =
            DependencyProperty.Register("Center", typeof(Point), typeof(CFivePointStar),
                new FrameworkPropertyMetadata(new Point(20.0, 20.0),
                    FrameworkPropertyMetadataOptions.AffectsMeasure));

        public Point Center
        {
            get { return (Point)GetValue(CenterProperty); }
            set { SetValue(CenterProperty, value); }
        }

        //Specify the size of the star
        public static readonly DependencyProperty SizeRProperty =
            DependencyProperty.Register("SizeR", typeof(double), typeof(CFivePointStar),
                new FrameworkPropertyMetadata(10.0, FrameworkPropertyMetadataOptions.AffectsMeasure));

        public double SizeR
        {
            get { return (double)GetValue(SizeRProperty); }
            set { SetValue(SizeRProperty, value); }
        }

        protected override Geometry DefiningGeometry
        {
            get
            {
                
                return m_PathGeometry;
            }
        }
    }
}

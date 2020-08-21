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
    public class CHeart : Shape
    {
        PathGeometry pathGeometry = new PathGeometry();
        public CHeart()
        {
            Stroke = Brushes.Black;
            Stretch = Stretch.Fill;
            PathFigure figure = new PathFigure();

            //Move - "M 241,200 "
            figure.StartPoint = new Point(241, 200);

            //Elliptical Arc Command - "A 20,20 0 0 0 200,240" + //A size rotationAngle isLargeArcFlag sweepDirectionFlag endPoint
            ArcSegment arcSegment1 = new ArcSegment
                (new Point(200,240),
                 new Size(20,20),
                 0,
                 false,
                 SweepDirection.Counterclockwise,
                 true);

            figure.Segments.Add(arcSegment1);

            //Cubic Bezier Curve Command - "C 210,250 240,270 240,270" + //C controlPoint1 controlPoint2 endPoint
            BezierSegment bezierSegment1 = new BezierSegment(new Point(210, 250), new Point(240, 270), new Point(240, 270), true);
            figure.Segments.Add(bezierSegment1);

            //Cubic Bezier Curve Command - "C 240,270 260,260 280,240" + //C controlPoint1 controlPoint2 endPoint
            BezierSegment bezierSegment2 = new BezierSegment(new Point(240, 270), new Point(260, 260), new Point(280, 240), true);
            figure.Segments.Add(bezierSegment2);

            //Elliptical Arc Command - "A 20,20 0 0 0 239,200";  //A size rotationAngle isLargeArcFlag sweepDirectionFlag endPoint
            ArcSegment arcSegment2 = new ArcSegment
                (new Point(239, 200),
                 new Size(20, 20),
                 0,
                 false,
                 SweepDirection.Counterclockwise,
                 true);

            figure.Segments.Add(arcSegment2);


            pathGeometry.Figures.Add(figure);
        }

        protected override Geometry DefiningGeometry
        {
            get { return pathGeometry;  }
        }
    }
}


//https://docs.microsoft.com/en-us/dotnet/framework/wpf/graphics-multimedia/path-markup-syntax
//М - Move - StartPoint
//L - Line - https://docs.microsoft.com/en-us/dotnet/framework/wpf/graphics-multimedia/how-to-create-a-line-using-a-linegeometry //or https://docs.microsoft.com/en-us/dotnet/framework/wpf/graphics-multimedia/how-to-create-a-linesegment-in-a-pathgeometry
//A - Elliptical Arc Command //https://docs.microsoft.com/en-us/dotnet/framework/wpf/graphics-multimedia/how-to-create-an-elliptical-arc
//C - Cubic Bezier Curve Command //https://docs.microsoft.com/en-us/dotnet/framework/wpf/graphics-multimedia/how-to-create-a-cubic-bezier-curve

//"M 241,200 " +
//    "A 20,20 0 0 0 200,240" + //A size rotationAngle isLargeArcFlag sweepDirectionFlag endPoint
//    "C 210,250 240,270 240,270" + //C controlPoint1 controlPoint2 endPoint
//    "C 240,270 260,260 280,240" + //C controlPoint1 controlPoint2 endPoint
//    "A 20,20 0 0 0 239,200";  //A size rotationAngle isLargeArcFlag sweepDirectionFlag endPoint


/*
 * <Path Stroke="Black" StrokeThickness="1">
      <Path.Data>
        <PathGeometry>
          <PathGeometry.Figures>
            <PathFigureCollection>
              <PathFigure StartPoint="10,100">
                <PathFigure.Segments>
                  <PathSegmentCollection>
                    <BezierSegment Point1="100,0" Point2="200,200" Point3="300,100" />
                  </PathSegmentCollection>
                </PathFigure.Segments>
              </PathFigure>
            </PathFigureCollection>
          </PathGeometry.Figures>
        </PathGeometry>
      </Path.Data>
    </Path>
 */

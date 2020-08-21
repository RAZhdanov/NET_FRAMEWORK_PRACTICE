using Additional_Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Additional_Project
{
    /* 
     * Реализуйте абстрактный класс Shape, содержащий метод Draw(), якобы рисующий фигуру (вывод строки на экран)  Создайте классы его потомков Triangle, Hexagon,Circle, Sphere
     * Создайте интерфейсы 
     * • IPoint, со свойством Point, выдающим количество точек в фигуре. 
     * • IDrawable, с методом Draw(), якобы рисующем фигуру (вывод строки на экран )
     * Реализуйте 
     * • IPointдля Triangle и Hexagon • IDrawable для Triangle (не явно) и Sphere(явно)
     * В основном классе: 
     * • Создайте метод AnalyzeShape(), принимающий Shape и распечатывающий, если возможно, кол-во точек в фигуре, и вызывающий метод Drawнапрямую и через интерфейс. 
     * • В методе Main создайте массив из Shapeс разными фигурами и проанализируйте их вызвав метод AnalyzeShape()
     */
    class Program
    {
        private static void AnalyzeShape(CShape shape)
        {
            //Direct invocation of Draw method
            shape.Draw();

            switch (shape)
            {
                case null:
                    {
                        break;
                    }
                case CTriangle obj:
                    {
                        //Invocation of draw method via interface
                        IDrawable idrawable_interface = obj;
                        idrawable_interface.Draw();

                        Console.WriteLine("The quantity of points in triangle shape is {0}", obj.Point);
                        break;
                    }
                case CHexagon obj:
                    {
                        Console.WriteLine("The quantity of points in hexagon shape is {0}", obj.Point);
                        break;
                    }
                case CCircle obj:
                    {
                        break;
                    }
                case CSphere obj:
                    {
                        //Invocation of draw method via interface
                        IDrawable idrawable_interface = obj;
                        idrawable_interface.Draw();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        static void Main(string[] args)
        {
            CShape[] arrShapes = { new CCircle(), new CSphere(), new CTriangle(), new CHexagon() };

            foreach(CShape sh in arrShapes)
            {
                AnalyzeShape(sh);
            }
        }
    }
}

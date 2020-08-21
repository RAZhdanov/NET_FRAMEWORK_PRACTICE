using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Additional_Project
{
    class CTriangle : CShape, Interfaces.IPoint, Interfaces.IDrawable
    {
        public int Point {
            get
            {
                return 3; // read-only instance property
            }
        }

        //Неявная реализация интерфейса
        public void Draw()
        {
            Console.WriteLine("Я нарисовал фигуру! - сказал класс: {0}", typeof(CTriangle).Name);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Additional_Project
{
    class CSphere : CShape, Interfaces.IDrawable
    {
        //Явная реализация интерфейса
        void Interfaces.IDrawable.Draw()
        {
            Console.WriteLine("Я нарисовал фигуру! - сказал класс: {0}", typeof(CSphere).Name);
        }
    }
}

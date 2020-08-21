using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Additional_Project
{
    abstract class CShape
    {
        //Реализуйте абстрактный класс Shape, содержащий метод Draw(), якобы рисующий фигуру (вывод строки на экран)
        public void Draw()
        {
            Console.WriteLine("Я нарисовал фигуру! - сказал класс: {0}", typeof(CShape).Name);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//интерфейс IDrawable, с методом Draw(), якобы рисующем фигуру (вывод строки на экран )
namespace Additional_Project.Interfaces
{
    //Заметка для самого себя: Все, что есть в интерфейсе является public!
    interface IDrawable
    {
        void Draw(); //it is a method for returning the text about the process of drawing
    }
}


/*
 * Интерфейс может содержать следующие члены 
 * • Методы 
 * • Свойства 
 * • Индексаторы 
 * • События 
 * Не могут содержать поля
 * Не могут содержать реализацию 
 * Члены интерфейса не могут быть статическими 
 * Члены интерфейса не могут иметь модификаторов 
 * Члены интерфейса всегда public
 */

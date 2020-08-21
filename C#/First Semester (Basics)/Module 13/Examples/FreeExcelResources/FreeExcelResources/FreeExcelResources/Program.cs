using System;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

// Демонстрация освобождения ресурсов при работе с COM объектами (Excel)
// Для наблюдения за Excel используйте диспетчер задач Windows

namespace FreeExcelResources
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyResource r = new MyResource()) // Создание объекта, работающего с неуправляемыми ресурсами
            {
                r.OpenExcel(); // Работа с неуправляемыми ресурсами
                Console.WriteLine("Excel открыт. Для его закрытия и освобождения ресурсов нажмите Enter");

                Console.ReadLine();
            } // Вызов Dispose() для освобождения ресурсов

            Console.WriteLine("Excel закрыт, и ресурсы освобождены");
            Console.ReadLine();
        }
    }

    public class MyResource : IDisposable
    {
        // запоминаем в отдельных переменных ссылки на COM объекты, чтобы их потом можно было явно очистить.
        Application excel;
        Workbooks workbooks;
        Workbook workbook;
        Worksheet worksheet;
        Range range;

        public void OpenExcel()
        {
            // Правило двух точек. 
            // При работе с COM объектами нельзя писать выражение с 2  и более точками, например, excel.Workbooks.Add(), поскольку потеряется ссылка на excel.Workbooks и ее нельзя будет очистить.

            excel = new Application();          // Открываем Excel
            workbooks = excel.Workbooks;        // Коллекция всех открытых книг
            workbook = workbooks.Add();         // Добавляем новую книгу
            worksheet = workbook.ActiveSheet;   // Ссылка на текущий (активный) лист
            range = worksheet.Cells;            // Диапазон ячеек. Запоминаем, чтобы потом очистить ссылку.
            range[1, 1] = "Привет";             // Помещаем строку в ячейку A1
            range[2, 1] = "Работаем с Excel";   // Помещаем строку в ячейку A2
            excel.Visible = true;               // Отображаем Excel (делаем его видимым пользователю)
        }

        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // отключает финализацию, т.е. вызов деструктора, а, следовательно, и объект будет удален в один проход сборщиком мусора
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // Удаление управляемых ресурсов. Вызов Dispose() у используемых объектах в полях
                }

                // Очистка неуправляемых ресурсов
                // Очистка всех ссылок на COM объекты. Мы их специально запоминали в отдельные переменные для очистки
                if (workbook != null && excel.ActiveWorkbook != null) workbook.Close(false);    // Закрываем книгу, не сохраняя ее. P.S. Немного грубоватые проверки (на случай, есть пользователь закрыл Excel), но для демонстрации подойдут
                if (excel != null) excel.Quit();    // Закрываем Excel
                // Очистка ссылок
                if (range != null) Marshal.ReleaseComObject(range);
                range = null;
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                worksheet = null;
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                workbook = null;
                if (workbooks != null) Marshal.ReleaseComObject(workbooks);
                workbooks = null;
                if (excel != null) Marshal.ReleaseComObject(excel);
                excel = null;
                // Установка параметра, о том, что мы уже провели очистку и нечего ее проводить дважды
                disposed = true;
            }
        }

        // Деструктор. Создан для случая, если забыли вызвать Dispose()
        ~MyResource()
        {
            Dispose(false);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Computers
{
    public class MainClass
    {
        public static void Main()
        {
            // Задание 1: используя объектную модель LINQ to XML, создайте XML учета компьютеров в маленьком офисе (разумеется, не загружая готовый XML из файла)
            XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
              new XElement("Computers",
                new XElement("Computer", new XAttribute("Name", "Chif"),
                    new XElement("Processor", new XAttribute("Vendor", "Intel"), new XAttribute("Model", "Intel Core I7"), new XAttribute("Frequency", "3")),
                    new XElement("Memory", new XAttribute("Volume", "4")),
                    new XElement("HDD", new XAttribute("Volume", "1500")),
                    new XElement("Mouse", "Logitech")),
                new XElement("Computer", new XAttribute("Name", "Workstation"),
                    new XElement("Processor", new XAttribute("Vendor", "Intel"), new XAttribute("Model", "Intel Core I3"), new XAttribute("Frequency", "2.6")),
                    new XElement("Memory", new XAttribute("Volume", "2")),
                    new XElement("HDD", new XAttribute("Volume", "1000")),
                    new XElement("Mouse", "Logitech")),
                new XElement("Computer", new XAttribute("Name", "AMD Workstation"),
                    new XElement("Processor", new XAttribute("Vendor", "AMD"), new XAttribute("Model", "AMD Ryzen 7"), new XAttribute("Frequency", "3")),
                    new XElement("Memory", new XAttribute("Volume", "3")),
                    new XElement("HDD", new XAttribute("Volume", "6000")),
                    new XElement("Mouse", "Microsoft"))));



            // 2. Используя LINQ to XML, распечатайте:
            // a. Распечатывание производителей процессоров
            Console.WriteLine("Производители процессоров:\n");
            foreach (string vendor in document.Descendants("Processor").Select(o=>o.Attribute("Vendor")).Select(o=>o.Value).Distinct())
            {
                Console.WriteLine(vendor);
            }



            // b. Распечатывание производителей мышек
            Console.WriteLine("\n\nПроизводители мышек:\n");
            foreach (string vendor in document.Descendants("Mouse").Select(o=>o.Value).Distinct())
            {
                Console.WriteLine(vendor);
            }

            // c. Распечатывание суммарного общего объёма дискового пространства
            Console.WriteLine("\n\nСуммарный общий объём дискового пространства на всех компьютерах:\n");

            Console.WriteLine(document.Descendants("HDD").Select(o => o.Attribute("Volume")).Select(o=>int.Parse(o.Value)).Sum());

            // d. Модернизация компьютеров
            document.Descendants("Memory").Select(o => o.Attribute("Volume")).Where(o => int.Parse(o.Value) < 4).ToList().ForEach(o => o.Value = (int.Parse(o.Value) + 8).ToString());

      
            
            // 3. Сохранение 
            document.Save("computers.xml");

            Console.ReadKey();

        }

    }
}

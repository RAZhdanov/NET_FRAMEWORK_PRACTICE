using System.IO;
using System.Xml.Serialization;

namespace ABCInc.DAL
{
    public class EmployeeProvider : IEmployeeProvider
    {
        public Employee[] LoadEmployees(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Employee[]));
                return (Employee[])serializer.Deserialize(fs);
            }
        }

        public void SaveEmployees(string path, Employee[] employees)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Employee[]));
                serializer.Serialize(fs, employees ?? new Employee[0]);
            }
        }
    }
}

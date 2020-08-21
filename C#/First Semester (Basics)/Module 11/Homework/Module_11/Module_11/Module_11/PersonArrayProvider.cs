using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Module_11
{
    class PersonListProvider : IProvider<List<Person>>
    {
        private readonly string _fileName;
        public PersonListProvider(string fileName)
        {
            _fileName = fileName;
        }

        
        public void Save(List<Person> valueToSave)
        {
            using (FileStream stream = new FileStream(_fileName, FileMode.Create))
            {
                XmlSerializer XML = new XmlSerializer(typeof(List<Person>));
                XML.Serialize(stream, valueToSave);
            }
        }
        public List<Person> Load()
        {
            using (var stream = new FileStream(_fileName, FileMode.Open)) 
            {
                XmlSerializer XML = new XmlSerializer(typeof(List<Person>));
                List<Person> result = (List<Person>)XML.Deserialize(stream);
                return result;
            }
        }
    }
}

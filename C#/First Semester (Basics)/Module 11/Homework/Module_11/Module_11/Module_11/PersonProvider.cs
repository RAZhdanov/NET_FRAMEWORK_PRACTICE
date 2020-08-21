using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Module_11
{
    class PersonProvider : IProvider<Person>
    {
        private readonly string _fileName;

        public PersonProvider(string fileName)
        {
            _fileName = fileName;
        }

        public Person Load()
        {
            using (FileStream stream = new FileStream(_fileName, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Person));
                Person result = (Person)serializer.Deserialize(stream);
                return result;
            }
        }

        public void Save(Person valueToSave)
        {
            using (FileStream stream = new FileStream(_fileName, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Person));
                serializer.Serialize(stream, valueToSave);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Module17.DAL
{
    public class BookArrayProvider : IProvider<Book[]>
    {
        private string m_fileName;

        public BookArrayProvider(string _fileName = "")
        {
            m_fileName = _fileName;
        }

        public void Save(Book[] valueToSave, string fileName = null)
        {
            string tmp_filename = fileName != null ? fileName : m_fileName;
            
            using (FileStream fs = new FileStream(tmp_filename, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Book[]));
                serializer.Serialize(fs, valueToSave);
            }
        }

        public Book[] Load(string fileName = null)
        {
            string tmp_filename = fileName != null ? fileName : m_fileName;

            using (FileStream fs = new FileStream(tmp_filename, FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Book[]));
                Book[] result = (Book[])xmlSerializer.Deserialize(fs);
                return result;
            }
        }
    }
}

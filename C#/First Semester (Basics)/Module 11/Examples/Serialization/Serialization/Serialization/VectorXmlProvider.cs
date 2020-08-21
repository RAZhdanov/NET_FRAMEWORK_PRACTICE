using System.IO;
using System.Xml.Serialization;

namespace Serialization
{
    public class VectorXmlProvider : IProvider<Vector3D>
    {
        private readonly string _fileName;

        public VectorXmlProvider(string fileName)
        {
            _fileName = fileName;
        }

        public void Save(Vector3D complex)
        {
            using (FileStream stream = new FileStream(_fileName, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Vector3D));
                serializer.Serialize(stream, complex);
            }
        }

        public Vector3D Load()
        {
            using (FileStream stream = new FileStream(_fileName, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Vector3D));
                Vector3D result = (Vector3D)serializer.Deserialize(stream);
                return result;
            }
        }
    }
}

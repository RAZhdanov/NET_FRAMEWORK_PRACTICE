using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    public class ComplexBinaryProvider : IProvider<Complex>
    {
        private readonly string _fileName;

        public ComplexBinaryProvider(string fileName)
        {
            _fileName = fileName;
        }

        public void Save(Complex complex)
        {
            using (FileStream stream = new FileStream(_fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, complex);
            }
        }

        public Complex Load()
        {
            using (FileStream stream = new FileStream(_fileName, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Complex result = (Complex)formatter.Deserialize(stream);
                return result;
            }
        }
    }
}

using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace Serialization
{
    public class ComplexSoapProvider : IProvider<Complex>
    {
        private readonly string _fileName;

        public ComplexSoapProvider(string fileName)
        {
            _fileName = fileName;
        }

        public void Save(Complex complex)
        {
            using (FileStream stream = new FileStream(_fileName, FileMode.Create))
            {
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(stream, complex);
            }
        }

        public Complex Load()
        {
            using (FileStream stream = new FileStream(_fileName, FileMode.Open))
            {
                SoapFormatter formatter = new SoapFormatter();
                Complex result = (Complex)formatter.Deserialize(stream);
                return result;
            }
        }
    }
}

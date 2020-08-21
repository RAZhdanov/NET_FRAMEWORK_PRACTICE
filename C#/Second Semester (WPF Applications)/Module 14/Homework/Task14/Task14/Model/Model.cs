using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5
{
    public class Model
    {
        public string m_path;
        public string m_text;
        public Encoding m_encoding;

        public Model()
        {
            m_path = null;
            m_text = null;
            m_encoding = null;
        }

        public Model(Encoding _encoding, string _path = null, string _text = null)
        {
            m_path = _path;
            m_text = _text;
            m_encoding = _encoding;
        }

        //Open Command
        public void Open(string _path, Encoding _encoding)
        {
            m_path = _path;
            m_encoding = _encoding;

            if(File.Exists(_path))
            {
                StreamReader sr = null;
                using (sr = new StreamReader(new FileStream(m_path, FileMode.Open, FileAccess.Read),
                                        m_encoding))
                {
                    m_text = sr.ReadToEnd();
                }
            }
        }

        //Save Command
        public void Save()
        {
            if (m_path == "") return;
            using (StreamWriter sw = new StreamWriter(
                                        new FileStream(m_path, FileMode.Truncate, FileAccess.Write),
                                        m_encoding))
            {
                sw.Write(m_text);
            }
        }

        //Save Command
        public void SaveAs(string _path)
        {
            m_path = _path;
            using (StreamWriter sr = new StreamWriter(new FileStream(m_path, FileMode.CreateNew, FileAccess.Write),
                                        m_encoding))
            {
                sr.Write(m_text);
            }
        }

        public void Clear()
        {
            m_text = null;
            m_path = null;
        }
        
    }
}

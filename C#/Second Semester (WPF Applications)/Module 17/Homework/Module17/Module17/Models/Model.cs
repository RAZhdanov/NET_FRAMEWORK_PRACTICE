using Module17.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module17.Models
{
    public class Model
    {
        /// <summary>
        /// properties
        /// </summary>
        public Book[] Books { get; set; }
        public string Path { get; set; } = "";


        
        private BookArrayProvider m_provider;
        
        public Model(BookArrayProvider provider)
        {
            m_provider = provider;
        }


        public bool LoadDefaultPath()
        {
            try
            {
                Books = m_provider.Load(Path);
            }
            catch(Exception)
            {
                return false;
            }

            return true;
        }
        public bool LoadSpecificPath(string _path)
        {
            try
            {
                Books = m_provider.Load(_path);
            }
            catch (Exception)
            {
                return false;
            }

            Path = _path;
            return true;
        }

        //SaveCommand
        public void Save()
        {
            m_provider.Save(Books, Path);
        }

        //SaveAs command
        public void SaveAs(string _path)
        {
            Path = _path;
            m_provider.Save(Books, Path);
        }
    }
}

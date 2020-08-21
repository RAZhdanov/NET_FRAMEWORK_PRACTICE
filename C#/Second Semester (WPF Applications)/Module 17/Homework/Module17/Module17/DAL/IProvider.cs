using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module17.DAL
{
    interface IProvider<T>
    {
        void Save(T valueToSave, string _filename);
        T Load(string _filename);
    }
}

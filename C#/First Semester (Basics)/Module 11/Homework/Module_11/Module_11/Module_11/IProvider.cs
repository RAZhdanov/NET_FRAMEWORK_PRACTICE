using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_11
{
    public interface IProvider<T>
    {
        void Save(T valueToSave);
        T Load();
    }
}

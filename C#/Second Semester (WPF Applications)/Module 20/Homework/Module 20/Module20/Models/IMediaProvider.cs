using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Module20.Models
{
    public interface IMediaProvider<T1>
    {
        void LoadMediaFile(T1 view, string _path);
    }
}

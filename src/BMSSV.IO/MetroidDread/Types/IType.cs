using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Types
{
    internal interface IType<T>
    {
        byte[] GetBytes();
        T FromStream(Stream stream);
    }
}

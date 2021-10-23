using BMSSV.IO.MetroidDread.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Properties
{
    public interface IProperty
    {
        string Name { get; }
        DataTypes DataType { get; }

        internal byte[] GetBytes();
    }
}

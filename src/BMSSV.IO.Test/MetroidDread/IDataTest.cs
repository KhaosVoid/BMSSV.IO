using BMSSV.IO.MetroidDread.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.Test.MetroidDread
{
    public interface IDataTest<T>
    {
        Assembly ExecutingAssembly { get; }
        string SampleFileResourceName { get; }

        void ReadData();
        void WriteData();
        D ReadDataFromStream<D>(Stream stream) where D : T;
        void ValidateData(T data);
    }
}

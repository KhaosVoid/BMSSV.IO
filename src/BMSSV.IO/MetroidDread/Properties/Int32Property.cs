using BMSSV.IO.MetroidDread.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Properties
{
    public class Int32Property : Property<int>
    {
        #region Ctor

        public Int32Property(string name, int value = default)
            : base(name, DataTypes.Int32, value)
        {

        }

        internal Int32Property(string name, Stream stream)
            : base(name, DataTypes.Int32, stream)
        {

        }

        #endregion Ctor

        #region Methods

        protected override byte[] GetRawValue()
        {
            return BinaryNumericConverter.GetBytes(Value);
        }

        protected override int GetValueFromStream(Stream stream)
        {
            byte[] buffer = new byte[sizeof(int)];

            stream.Read(buffer, 0, buffer.Length);

            return BinaryNumericConverter.ToInt32(buffer);
        }

        #endregion Methods
    }
}

using BMSSV.IO.MetroidDread.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Properties
{
    public class UInt32Property : Property<uint>
    {
        #region Ctor

        public UInt32Property(string name, uint value = default)
            : base(name, DataTypes.UInt32, value)
        {

        }

        internal UInt32Property(string name, Stream stream)
            : base(name, DataTypes.UInt32, stream)
        {

        }

        #endregion Ctor

        #region Methods

        protected override byte[] GetRawValue()
        {
            return BinaryNumericConverter.GetBytes(Value);
        }

        protected override uint GetValueFromStream(Stream stream)
        {
            byte[] buffer = new byte[sizeof(uint)];

            stream.Read(buffer, 0, buffer.Length);

            return BinaryNumericConverter.ToUInt32(buffer);
        }

        #endregion Methods
    }
}

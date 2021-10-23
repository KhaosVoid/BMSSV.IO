using BMSSV.IO.MetroidDread.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Properties
{
    public class FloatProperty : Property<float>
    {
        #region Ctor

        public FloatProperty(string name, float value = default)
            : base(name, DataTypes.Float, value)
        {

        }

        internal FloatProperty(string name, Stream stream)
            : base(name, DataTypes.Float, stream)
        {

        }

        #endregion Ctor

        #region Methods

        protected override byte[] GetRawValue()
        {
            return BitConverter.GetBytes(Value);
        }

        protected override float GetValueFromStream(Stream stream)
        {
            byte[] buffer = new byte[sizeof(float)];

            stream.Read(buffer, 0, buffer.Length);

            return BinaryNumericConverter.ToSingle(buffer);
        }

        #endregion Methods
    }
}

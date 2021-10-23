using BMSSV.IO.MetroidDread.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Properties
{
    public class BooleanArrayProperty : Property<bool[]>
    {
        #region Ctor

        public BooleanArrayProperty(string name, bool[] value = null)
            : base(name, DataTypes.BooleanArray, value)
        {

        }

        internal BooleanArrayProperty(string name, Stream stream)
            : base(name, DataTypes.BooleanArray, stream)
        {

        }

        #endregion Ctor

        #region Methods

        protected override byte[] GetRawValue()
        {
            List<byte> rawValue = new List<byte>();

            rawValue.AddRange(BinaryNumericConverter.GetBytes(Value.Length));

            for (int i = 0; i < Value.Length; i++)
                rawValue.AddRange(BitConverter.GetBytes(Value[i]));

            return rawValue.ToArray();
        }

        protected override bool[] GetValueFromStream(Stream stream)
        {
            List<bool> values = new List<bool>();
            int valuesLength;
            byte[] buffer = new byte[sizeof(int)];

            stream.Read(buffer, 0, buffer.Length);
            valuesLength = BinaryNumericConverter.ToInt32(buffer);

            for (int i = 0; i < valuesLength; i++)
            {
                buffer = new byte[sizeof(bool)];

                stream.Read(buffer, 0, buffer.Length);

                values.Add(
                    BitConverter.ToBoolean(buffer));
            }

            return values.ToArray();
        }

        #endregion Methods
    }
}

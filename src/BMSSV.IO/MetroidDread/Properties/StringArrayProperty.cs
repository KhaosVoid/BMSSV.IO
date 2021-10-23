using BMSSV.IO.MetroidDread.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Properties
{
    public class StringArrayProperty : Property<string[]>
    {
        #region Ctor

        public StringArrayProperty(string name, string[] value = null)
            : base(name, DataTypes.StringArray, value)
        {

        }

        internal StringArrayProperty(string name, Stream stream)
            : base(name, DataTypes.StringArray, stream)
        {

        }

        #endregion Ctor

        #region Methods

        protected override byte[] GetRawValue()
        {
            List<byte> rawValue = new List<byte>();

            rawValue.AddRange(BinaryNumericConverter.GetBytes(Value.Length));

            for (int i = 0; i < Value.Length; i++)
                rawValue.AddRange(Encoding.UTF8.GetBytes(Value[i] + (char)0x00));

            return rawValue.ToArray();
        }

        protected override string[] GetValueFromStream(Stream stream)
        {
            List<string> values = new List<string>();
            int valuesLength;
            byte[] buffer = new byte[sizeof(int)];

            stream.Read(buffer, 0, buffer.Length);
            valuesLength = BinaryNumericConverter.ToInt32(buffer);

            for (int i = 0; i < valuesLength; i++)
            {
                long lastPosition = stream.Position;
                int valueNullTerminatorIndex;

                buffer = new byte[1024];
                stream.Read(buffer, 0, buffer.Length);
                valueNullTerminatorIndex = Array.IndexOf(buffer, (byte)0x00);

                buffer = new byte[valueNullTerminatorIndex + 1];
                stream.Position = lastPosition;
                stream.Read(buffer, 0, buffer.Length);

                values.Add(Encoding.UTF8.GetString(buffer).Trim((char)0x00));
            }

            return values.ToArray();
        }

        #endregion Methods
    }
}

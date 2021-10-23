using BMSSV.IO.MetroidDread.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Properties
{
    public class StringProperty : Property<string>
    {
        #region Ctor

        public StringProperty(string name, string value = null)
            : base (name, DataTypes.String, value)
        {

        }

        internal StringProperty(string name, Stream stream)
            : base(name, DataTypes.String, stream)
        {

        }

        #endregion Ctor

        #region Methods

        protected override byte[] GetRawValue()
        {
            return Encoding.UTF8.GetBytes(Value + (char)0x00);
        }

        protected override string GetValueFromStream(Stream stream)
        {
            long lastPosition = stream.Position;
            int valueNullTerminatorIndex;
            byte[] buffer = new byte[1024];

            stream.Read(buffer, 0, buffer.Length);
            valueNullTerminatorIndex = Array.IndexOf(buffer, (byte)0x00);

            buffer = new byte[valueNullTerminatorIndex + 1];
            stream.Position = lastPosition;
            stream.Read(buffer, 0, buffer.Length);

            return Encoding.UTF8.GetString(buffer).Trim((char)0x00);
        }

        #endregion Methods
    }
}

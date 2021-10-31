using BMSSV.IO.MetroidDread.Enums;
using BMSSV.IO.MetroidDread.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Properties
{
    public class MinimapVisibilityArrayProperty : Property<MinimapVisibility[]>
    {
        #region Ctor

        public MinimapVisibilityArrayProperty(string name, MinimapVisibility[] value = null)
            : base(name, DataTypes.MinimapVisibilityArray, value)
        {

        }

        internal MinimapVisibilityArrayProperty(string name, Stream stream)
            : base(name, DataTypes.MinimapVisibilityArray, stream)
        {

        }

        #endregion Ctor

        #region Methods

        protected override byte[] GetRawValue()
        {
            List<byte> rawValue = new List<byte>();

            rawValue.AddRange(BinaryNumericConverter.GetBytes(Value.Length));

            for (int i = 0; i < Value.Length; i++)
                rawValue.AddRange(Value[i].GetBytes());

            return rawValue.ToArray();
        }

        protected override MinimapVisibility[] GetValueFromStream(Stream stream)
        {
            MinimapVisibility[] values;
            int valuesLength;
            byte[] buffer = new byte[sizeof(int)];

            stream.Read(buffer, 0, buffer.Length);

            valuesLength = BinaryNumericConverter.ToInt32(buffer);
            values = new MinimapVisibility[valuesLength];

            for (int i = 0; i < valuesLength; i++)
                values[i] = MinimapVisibility.FromStream(stream);

            return values;
        }

        #endregion Methods
    }
}

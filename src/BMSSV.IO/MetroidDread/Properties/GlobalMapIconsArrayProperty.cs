using BMSSV.IO.Attributes;
using BMSSV.IO.MetroidDread.Enums;
using BMSSV.IO.MetroidDread.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Properties
{
    public class GlobalMapIconsArrayProperty : Property<GlobalMapIcons[]>
    {
        #region Ctor

        public GlobalMapIconsArrayProperty(string name, GlobalMapIcons[] value)
            : base(name, DataTypes.GlobalMapIconsArray, value)
        {

        }

        internal GlobalMapIconsArrayProperty(string name, Stream stream)
            : base(name, DataTypes.GlobalMapIconsArray, stream)
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

        protected override GlobalMapIcons[] GetValueFromStream(Stream stream)
        {
            GlobalMapIcons[] values;
            int valuesLength;
            byte[] buffer = new byte[sizeof(int)];

            stream.Read(buffer, 0, buffer.Length);

            valuesLength = BinaryNumericConverter.ToInt32(buffer);
            values = new GlobalMapIcons[valuesLength];

            for (int i = 0; i < valuesLength; i++)
                values[i] = GlobalMapIcons.FromStream(stream);

            return values;
        }

        #endregion Methods
    }
}

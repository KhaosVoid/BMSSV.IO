using BMSSV.IO.Attributes;
using BMSSV.IO.MetroidDread.Enums;
using BMSSV.IO.MetroidDread.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Properties
{
    public class MissionLogEntriesArrayProperty : Property<MissionLogEntry[]>
    {
        #region Ctor

        public MissionLogEntriesArrayProperty(string name, MissionLogEntry[] value = null)
            : base(name, DataTypes.MissionLogEntriesArray, value)
        {

        }

        internal MissionLogEntriesArrayProperty(string name, Stream stream)
            : base(name, DataTypes.MissionLogEntriesArray, stream)
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

        protected override MissionLogEntry[] GetValueFromStream(Stream stream)
        {
            MissionLogEntry[] values;
            int valuesLength;
            byte[] buffer = new byte[sizeof(int)];

            stream.Read(buffer, 0, buffer.Length);

            valuesLength = BinaryNumericConverter.ToInt32(buffer);
            values = new MissionLogEntry[valuesLength];

            for (int i = 0; i < valuesLength; i++)
                values[i] = MissionLogEntry.FromStream(stream);

            return values;
        }

        #endregion Methods
    }
}

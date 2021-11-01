using BMSSV.IO.MetroidDread.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Properties
{
    public class Vector3Property : Property<Vector3>
    {
        #region Ctor

        public Vector3Property(string name, Vector3 value = default)
            : base(name, DataTypes.Vector3, value)
        {

        }

        internal Vector3Property(string name, Stream stream)
            : base(name, DataTypes.Vector3, stream)
        {

        }

        #endregion Ctor

        #region Methods

        protected override byte[] GetRawValue()
        {
            List<byte> rawValue = new List<byte>();

            rawValue.AddRange(BinaryNumericConverter.GetBytes(Value.X));
            rawValue.AddRange(BinaryNumericConverter.GetBytes(Value.Y));
            rawValue.AddRange(BinaryNumericConverter.GetBytes(Value.Z));

            return rawValue.ToArray();
        }

        protected override Vector3 GetValueFromStream(Stream stream)
        {
            float x;
            float y;
            float z;
            byte[] buffer = new byte[sizeof(float)];

            stream.Read(buffer, 0, buffer.Length);
            x = BinaryNumericConverter.ToSingle(buffer);

            stream.Read(buffer, 0, buffer.Length);
            y = BinaryNumericConverter.ToSingle(buffer);

            stream.Read(buffer, 0, buffer.Length);
            z = BinaryNumericConverter.ToSingle(buffer);

            return new Vector3(x, y, z);
        }

        #endregion Methods
    }
}

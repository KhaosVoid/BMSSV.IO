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
    public class Vector2Property : Property<Vector2>
    {
        #region Ctor

        public Vector2Property(string name, Vector2 value = default)
            : base(name, DataTypes.Vector2, value)
        {

        }

        internal Vector2Property(string name, Stream stream)
            : base(name, DataTypes.Vector2, stream)
        {

        }

        #endregion Ctor

        #region Methods

        protected override byte[] GetRawValue()
        {
            List<byte> rawValue = new List<byte>();

            rawValue.AddRange(BinaryNumericConverter.GetBytes(Value.X));
            rawValue.AddRange(BinaryNumericConverter.GetBytes(Value.Y));

            return rawValue.ToArray();
        }

        protected override Vector2 GetValueFromStream(Stream stream)
        {
            float x;
            float y;
            byte[] buffer = new byte[sizeof(float)];

            stream.Read(buffer, 0, buffer.Length);
            x = BinaryNumericConverter.ToSingle(buffer);

            stream.Read(buffer, 0, buffer.Length);
            y = BinaryNumericConverter.ToSingle(buffer);

            return new Vector2(x, y);
        }

        #endregion Methods
    }
}

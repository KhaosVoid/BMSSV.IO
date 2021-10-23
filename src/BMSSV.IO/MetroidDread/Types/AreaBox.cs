using BMSSV.IO.Attributes;
using BMSSV.IO.MetroidDread.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BMSSV.IO.MetroidDread.Types
{
    public class AreaBox : IType<AreaBox>
    {
        #region Properties

        [PropertyId(PropertyIds.AreaBoxMin)]
        public Vector2 Min { get; set; }

        [PropertyId(PropertyIds.AreaBoxMax)]
        public Vector2 Max { get; set; }

        #endregion Properties

        #region Methods

        byte[] IType<AreaBox>.GetBytes()
        {
            return GetBytes();
        }

        internal byte[] GetBytes()
        {
            List<byte> bytes = new List<byte>();
            byte[] propertyIdsLength = BinaryNumericConverter.GetBytes(2);
            var minPropertyId = typeof(AreaBox)
                .GetProperty(nameof(Min))
                .GetCustomAttribute<PropertyIdAttribute>()
                .Id;
            var maxPropertyId = typeof(AreaBox)
                .GetProperty(nameof(Max))
                .GetCustomAttribute<PropertyIdAttribute>()
                .Id;

            bytes.AddRange(propertyIdsLength);
            bytes.AddRange(BinaryNumericConverter.GetBytes((ulong)minPropertyId, true));
            bytes.AddRange(BinaryNumericConverter.GetBytes(Min.X));
            bytes.AddRange(BinaryNumericConverter.GetBytes(Min.Y));
            bytes.AddRange(BinaryNumericConverter.GetBytes((ulong)maxPropertyId, true));
            bytes.AddRange(BinaryNumericConverter.GetBytes(Max.X));
            bytes.AddRange(BinaryNumericConverter.GetBytes(Max.Y));

            return bytes.ToArray();
        }

        AreaBox IType<AreaBox>.FromStream(Stream stream)
        {
            return FromStream(stream);
        }

        internal static AreaBox FromStream(Stream stream)
        {
            AreaBox areaBox = new AreaBox();
            byte[] buffer = new byte[sizeof(uint)];

            stream.Read(buffer, 0, buffer.Length);

            int valuesLength = BinaryNumericConverter.ToInt32(buffer);

            for (int i = 0; i < valuesLength; i++)
            {
                float x;
                float y;

                buffer = new byte[sizeof(PropertyIds)];

                stream.Read(buffer, 0, buffer.Length);

                PropertyIds propertyId = (PropertyIds)BinaryNumericConverter.ToUInt64(buffer, true);
                buffer = new byte[sizeof(float)];

                stream.Read(buffer, 0, buffer.Length);
                x = BinaryNumericConverter.ToSingle(buffer);

                stream.Read(buffer, 0, buffer.Length);
                y = BinaryNumericConverter.ToSingle(buffer);

                switch (propertyId)
                {
                    case PropertyIds.AreaBoxMin:
                        areaBox.Min = new Vector2(x, y);
                        break;

                    case PropertyIds.AreaBoxMax:
                        areaBox.Max = new Vector2(x, y);
                        break;

                    default:
                        throw new InvalidOperationException(
                            $"Unrecognized PropertyId.");
                }
            }

            return areaBox;
        }

        #endregion Methods
    }
}

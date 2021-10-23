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
    public class GlobalMapIcon : IType<GlobalMapIcon>
    {
        #region Properties

        [PropertyId(PropertyIds.GlobalMapIconId)]
        public string Id { get; set; }

        [PropertyId(PropertyIds.GlobalMapIconPosition)]
        public Vector2 Position { get; set; }

        #endregion Properties

        #region Methods

        byte[] IType<GlobalMapIcon>.GetBytes()
        {
            return GetBytes();
        }

        internal byte[] GetBytes()
        {
            List<byte> bytes = new List<byte>();
            byte[] propertyIdsLength = BinaryNumericConverter.GetBytes(2);
            var globalMapIconIdPropertyId = typeof(GlobalMapIcon)
                .GetProperty(nameof(Id))
                .GetCustomAttribute<PropertyIdAttribute>()
                .Id;
            var globalMapIconPositionPropertyId = typeof(GlobalMapIcon)
                .GetProperty(nameof(Position))
                .GetCustomAttribute<PropertyIdAttribute>()
                .Id;

            bytes.AddRange(propertyIdsLength);
            bytes.AddRange(BinaryNumericConverter.GetBytes((ulong)globalMapIconIdPropertyId, true));
            bytes.AddRange(Encoding.UTF8.GetBytes(Id + (char)0x00));
            bytes.AddRange(BinaryNumericConverter.GetBytes((ulong)globalMapIconPositionPropertyId, true));
            bytes.AddRange(BinaryNumericConverter.GetBytes(Position.X));
            bytes.AddRange(BinaryNumericConverter.GetBytes(Position.Y));

            return bytes.ToArray();
        }

        GlobalMapIcon IType<GlobalMapIcon>.FromStream(Stream stream)
        {
            return FromStream(stream);
        }

        internal static GlobalMapIcon FromStream(Stream stream)
        {
            GlobalMapIcon globalMapIcon = new GlobalMapIcon();
            long lastPosition;
            byte[] buffer = new byte[sizeof(int)];

            stream.Read(buffer, 0, buffer.Length);

            int propertyIdsLength = BinaryNumericConverter.ToInt32(buffer);

            for (int v = 0; v < propertyIdsLength; v++)
            {
                buffer = new byte[sizeof(PropertyIds)];

                stream.Read(buffer, 0, buffer.Length);

                PropertyIds propertyId = (PropertyIds)BinaryNumericConverter.ToUInt64(buffer, true);

                switch (propertyId)
                {
                    case PropertyIds.GlobalMapIconId:
                        lastPosition = stream.Position;
                        int iconNameNullTerminatorIndex;
                        buffer = new byte[1024];
                        
                        stream.Read(buffer, 0, buffer.Length);

                        iconNameNullTerminatorIndex = Array.IndexOf(buffer, (byte)0x00);
                        buffer = new byte[iconNameNullTerminatorIndex + 1];
                        stream.Position = lastPosition;

                        stream.Read(buffer, 0, buffer.Length);

                        globalMapIcon.Id = Encoding.UTF8.GetString(buffer).Trim((char)0x00);
                        break;

                    case PropertyIds.GlobalMapIconPosition:
                        float x;
                        float y;

                        buffer = new byte[sizeof(float)];
                        stream.Read(buffer, 0, buffer.Length);

                        x = BinaryNumericConverter.ToSingle(buffer);

                        buffer = new byte[sizeof(float)];
                        stream.Read(buffer, 0, buffer.Length);

                        y = BinaryNumericConverter.ToSingle(buffer);

                        globalMapIcon.Position = new Vector2(x, y);
                        break;

                    default:
                        throw new InvalidOperationException(
                            $"Unrecognized PropertyId.");
                }
            }

            return globalMapIcon;
        }

        #endregion Methods
    }
}

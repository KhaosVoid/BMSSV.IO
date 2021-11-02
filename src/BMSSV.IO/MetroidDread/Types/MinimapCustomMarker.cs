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
    public class MinimapCustomMarker : IType<MinimapCustomMarker>
    {
        #region Properties

        [PropertyId(PropertyIds.MinimapCustomMarkerId)]
        public int Id { get; set; }

        [PropertyId(PropertyIds.MinimapCustomMarkerType)]
        public MinimapCustomMarkerTypes Type { get; set; }

        [PropertyId(PropertyIds.MinimapCustomMarkerPosition)]
        public Vector2 Position { get; set; }

        [PropertyId(PropertyIds.MinimapCustomMarkerTargetId)]
        public string TargetId { get; set; }

        [PropertyId(PropertyIds.MinimapCustomMarkerTargetSlot)]
        public int TargetSlot { get; set; }

        #endregion Properties

        #region Methods

        byte[] IType<MinimapCustomMarker>.GetBytes()
        {
            return GetBytes();
        }

        internal byte[] GetBytes()
        {
            List<byte> bytes = new List<byte>();
            byte[] propertyIdsLength = BinaryNumericConverter.GetBytes(5);
            var idPropertyId = typeof(MinimapCustomMarker)
                .GetProperty(nameof(Id))
                .GetCustomAttribute<PropertyIdAttribute>()
                .Id;
            var typePropertyId = typeof(MinimapCustomMarker)
                .GetProperty(nameof(Type))
                .GetCustomAttribute<PropertyIdAttribute>()
                .Id;
            var positionPropertyId = typeof(MinimapCustomMarker)
                .GetProperty(nameof(Position))
                .GetCustomAttribute<PropertyIdAttribute>()
                .Id;
            var targetIdPropertyId = typeof(MinimapCustomMarker)
                .GetProperty(nameof(TargetId))
                .GetCustomAttribute<PropertyIdAttribute>()
                .Id;
            var targetSlotPropertyId = typeof(MinimapCustomMarker)
                .GetProperty(nameof(TargetSlot))
                .GetCustomAttribute<PropertyIdAttribute>()
                .Id;

            bytes.AddRange(propertyIdsLength);
            bytes.AddRange(BinaryNumericConverter.GetBytes((ulong)idPropertyId, true));
            bytes.AddRange(BinaryNumericConverter.GetBytes(Id));
            bytes.AddRange(BinaryNumericConverter.GetBytes((ulong)typePropertyId, true));
            bytes.AddRange(BinaryNumericConverter.GetBytes((int)Type));
            bytes.AddRange(BinaryNumericConverter.GetBytes((ulong)positionPropertyId, true));
            bytes.AddRange(BinaryNumericConverter.GetBytes(Position.X));
            bytes.AddRange(BinaryNumericConverter.GetBytes(Position.Y));
            bytes.AddRange(BinaryNumericConverter.GetBytes((ulong)targetIdPropertyId, true));
            bytes.AddRange(Encoding.UTF8.GetBytes(TargetId + (char)0x00));
            bytes.AddRange(BinaryNumericConverter.GetBytes((ulong)targetSlotPropertyId, true));
            bytes.AddRange(BinaryNumericConverter.GetBytes(TargetSlot));

            return bytes.ToArray();
        }

        MinimapCustomMarker IType<MinimapCustomMarker>.FromStream(Stream stream)
        {
            return FromStream(stream);
        }

        internal static MinimapCustomMarker FromStream(Stream stream)
        {
            MinimapCustomMarker minimapCustomMarker = new MinimapCustomMarker();
            byte[] buffer = new byte[sizeof(int)];

            stream.Read(buffer, 0, buffer.Length);

            int valuesLength = BinaryNumericConverter.ToInt32(buffer);

            for (int i = 0; i < valuesLength; i++)
            {
                buffer = new byte[sizeof(PropertyIds)];

                stream.Read(buffer, 0, buffer.Length);

                PropertyIds propertyId = (PropertyIds)BinaryNumericConverter.ToUInt64(buffer, true);

                switch (propertyId)
                {
                    case PropertyIds.MinimapCustomMarkerId:
                        buffer = new byte[sizeof(int)];
                        stream.Read(buffer, 0, buffer.Length);
                        minimapCustomMarker.Id = BinaryNumericConverter.ToInt32(buffer);
                        break;

                    case PropertyIds.MinimapCustomMarkerType:
                        buffer = new byte[sizeof(MinimapCustomMarkerTypes)];
                        stream.Read(buffer, 0, buffer.Length);
                        minimapCustomMarker.Type = (MinimapCustomMarkerTypes)BinaryNumericConverter.ToInt32(buffer);
                        break;

                    case PropertyIds.MinimapCustomMarkerPosition:
                        float x;
                        float y;
                        buffer = new byte[sizeof(float)];
                        
                        stream.Read(buffer, 0, buffer.Length);
                        x = BinaryNumericConverter.ToSingle(buffer);

                        stream.Read(buffer, 0, buffer.Length);
                        y = BinaryNumericConverter.ToSingle(buffer);

                        minimapCustomMarker.Position = new Vector2(x, y);
                        break;

                    case PropertyIds.MinimapCustomMarkerTargetId:
                        long lastPosition = stream.Position;
                        int nullTerminatorIndex;
                        buffer = new byte[1024];

                        stream.Read(buffer, 0, buffer.Length);
                        
                        nullTerminatorIndex = Array.IndexOf(buffer, (byte)0x00);
                        buffer = new byte[nullTerminatorIndex + 1];
                        stream.Position = lastPosition;

                        stream.Read(buffer, 0, buffer.Length);

                        minimapCustomMarker.TargetId = Encoding.UTF8.GetString(buffer).Trim((char)0x00);
                        break;

                    case PropertyIds.MinimapCustomMarkerTargetSlot:
                        buffer = new byte[sizeof(int)];
                        stream.Read(buffer, 0, buffer.Length);
                        minimapCustomMarker.TargetSlot = BinaryNumericConverter.ToInt32(buffer);
                        break;

                    default:
                        throw new InvalidOperationException(
                            $"Unrecognized PropertyId.");
                }
            }

            return minimapCustomMarker;
        }

        #endregion Methods
    }
}

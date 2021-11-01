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
    public class CheckpointOffset : IType<CheckpointOffset>
    {
        #region Properties

        [PropertyId(PropertyIds.CheckpointOffsetId)]
        public string Id { get; set; }

        [PropertyId(PropertyIds.CheckpointOffsetPosition)]
        public Vector3 Position { get; set; }

        [PropertyId(PropertyIds.CheckpointOffsetAngle)]
        public Vector3 Angle { get; set; }

        #endregion Properties

        #region Methods

        byte[] IType<CheckpointOffset>.GetBytes()
        {
            return GetBytes();
        }

        internal byte[] GetBytes()
        {
            List<byte> bytes = new List<byte>();
            byte[] propertyIdsLenth = BinaryNumericConverter.GetBytes(3);
            var idPropertyId = typeof(CheckpointOffset)
                .GetProperty(nameof(Id))
                .GetCustomAttribute<PropertyIdAttribute>()
                .Id;
            var positionPropertyId = typeof(CheckpointOffset)
                .GetProperty(nameof(Position))
                .GetCustomAttribute<PropertyIdAttribute>()
                .Id;
            var anglePropertyId = typeof(CheckpointOffset)
                .GetProperty(nameof(Angle))
                .GetCustomAttribute<PropertyIdAttribute>()
                .Id;

            bytes.AddRange(propertyIdsLenth);
            bytes.AddRange(BinaryNumericConverter.GetBytes((ulong)idPropertyId, true));
            bytes.AddRange(Encoding.UTF8.GetBytes(Id + (char)0x00));
            bytes.AddRange(BinaryNumericConverter.GetBytes((ulong)positionPropertyId, true));
            bytes.AddRange(BinaryNumericConverter.GetBytes(Position.X));
            bytes.AddRange(BinaryNumericConverter.GetBytes(Position.Y));
            bytes.AddRange(BinaryNumericConverter.GetBytes(Position.Z));
            bytes.AddRange(BinaryNumericConverter.GetBytes((ulong)anglePropertyId, true));
            bytes.AddRange(BinaryNumericConverter.GetBytes(Angle.X));
            bytes.AddRange(BinaryNumericConverter.GetBytes(Angle.Y));
            bytes.AddRange(BinaryNumericConverter.GetBytes(Angle.Z));

            return bytes.ToArray();
        }

        CheckpointOffset IType<CheckpointOffset>.FromStream(Stream stream)
        {
            return FromStream(stream);
        }

        internal static CheckpointOffset FromStream(Stream stream)
        {
            CheckpointOffset checkpointOffset = new CheckpointOffset();
            byte[] buffer = new byte[sizeof(int)];

            stream.Read(buffer, 0, buffer.Length);

            int valuesLength = BinaryNumericConverter.ToInt32(buffer);

            for (int i = 0; i < valuesLength; i++)
            {
                float x;
                float y;
                float z;

                buffer = new byte[sizeof(PropertyIds)];

                stream.Read(buffer, 0, buffer.Length);

                PropertyIds propertyId = (PropertyIds)BinaryNumericConverter.ToUInt64(buffer, true);
                
                switch (propertyId)
                {
                    case PropertyIds.CheckpointOffsetId:
                        long lastPosition = stream.Position;
                        int idNullTerminatorIndex;
                        buffer = new byte[1024];

                        stream.Read(buffer, 0, buffer.Length);

                        idNullTerminatorIndex = Array.IndexOf(buffer, (byte)0x00);
                        buffer = new byte[idNullTerminatorIndex + 1];
                        stream.Position = lastPosition;

                        stream.Read(buffer, 0, buffer.Length);

                        checkpointOffset.Id = Encoding.UTF8.GetString(buffer).Trim((char)0x00);
                        break;

                    case PropertyIds.CheckpointOffsetPosition:
                        buffer = new byte[sizeof(float)];

                        stream.Read(buffer, 0, buffer.Length);
                        x = BinaryNumericConverter.ToSingle(buffer);

                        stream.Read(buffer, 0, buffer.Length);
                        y = BinaryNumericConverter.ToSingle(buffer);

                        stream.Read(buffer, 0, buffer.Length);
                        z = BinaryNumericConverter.ToSingle(buffer);

                        checkpointOffset.Position = new Vector3(x, y, z);
                        break;

                    case PropertyIds.CheckpointOffsetAngle:
                        buffer = new byte[sizeof(float)];

                        stream.Read(buffer, 0, buffer.Length);
                        x = BinaryNumericConverter.ToSingle(buffer);

                        stream.Read(buffer, 0, buffer.Length);
                        y = BinaryNumericConverter.ToSingle(buffer);

                        stream.Read(buffer, 0, buffer.Length);
                        z = BinaryNumericConverter.ToSingle(buffer);

                        checkpointOffset.Angle = new Vector3(x, y, z);
                        break;

                    default:
                        throw new InvalidOperationException(
                            $"Unrecognized PropertyId.");
                }
            }

            return checkpointOffset;
        }

        #endregion Methods
    }
}
